using System.Net.Sockets;
using System.Net;
using Server.Handlers;
using Server.Data;

namespace Server
{

    internal class Server
    {

        private const int _port = 8888;
        private static TcpListener _listener;
        private Logger _logger;

        private HandlersContainer _handlers;
        private ServerCommandLine.ServerCommandLine _commandLine;

        private Utils.Scheduler _userSaveScheduler;
        private Utils.Scheduler _recordsSaveScheduler;

        public Server()
        {
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), _port);

            _logger = new Logger("logs.txt", true);

            _handlers = new HandlersContainer();
            _handlers.AddHandler(new UserHandler());
            _handlers.AddHandler(new SpyHandler());

            _commandLine = new ServerCommandLine.ServerCommandLine();

            Task.Run(async () => {
                await DataWriterReader.LoadRecordsAsync("records.json");
                await DataWriterReader.LoadUsersAsync("users.json");
            }).Wait();

            _userSaveScheduler = new Utils.Scheduler(async () => await DataWriterReader.SaveUsersToFile(), new TimeSpan(0, 2, 0));
            _recordsSaveScheduler = new Utils.Scheduler(async () => await DataWriterReader.SaveRecordsToFile(), new TimeSpan(0, 2, 0));
        }

        private void StartTerminalMenu()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    ConsoleKeyInfo input_key = Console.ReadKey();
                    if (input_key.Key != ConsoleKey.Enter)
                        continue;
                   
                    _logger.DisableConsoleOutput();
                    _commandLine.Start();
                    _logger.EnableConsoleOutput();
                }
            });
        }

        public void Run()
        {
            TcpClient client = null;
            try
            {
                StartTerminalMenu();

                _userSaveScheduler.Run();
                _recordsSaveScheduler.Run();

                _listener.Start();
                Console.WriteLine("Wait for connection (type Enter for activate server interface)...");

                while (true)
                {
                    client = _listener.AcceptTcpClient();
                    _logger.Log("connection", client.Client.RemoteEndPoint?.ToString(), "");
                    Task.Run(async () => {
                        ClientObject clientObject = new ClientObject(client, _handlers, _logger);
                        await clientObject.Process();
                    });
                }
            }
            catch (Exception ex)
            {
                _logger.Log(ex.ToString(), client.Client.RemoteEndPoint?.ToString(), "");
            }
            finally
            {
                if (_listener != null)
                    _listener.Stop();

                _userSaveScheduler.Stop();
                _recordsSaveScheduler.Stop();
            }
        }
    
    }
}
