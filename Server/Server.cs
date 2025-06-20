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

        public Server()
        {
            _listener = new TcpListener(IPAddress.Parse("127.0.0.1"), _port);

            _logger = new Logger("logs.txt", true);

            _handlers = new HandlersContainer();
            _handlers.AddHandler(new UserHandler());
            _handlers.AddHandler(new SpyHandler());

            UsersContainer.AddUser("root", "root");
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
                    Console.WriteLine("Hello admin!");
                    _logger.DisableConsoleOutput();

                    bool terminalWork = true;
                    while (terminalWork)
                    {
                        Console.Write(": ");
                        string? input = Console.ReadLine();
                        if (input == null)
                            continue;

                        switch (input)
                        {
                            case "help":
                                Console.WriteLine("");
                                break;
                            case "exit":
                                terminalWork = false;
                                break;
                            default:
                                Console.WriteLine("Inknown command! Exter help to get commands list");
                                break;
                        }


                    }
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
            }
        }
    
    }
}
