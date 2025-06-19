using System.Net.Sockets;
using System.Net;
using Server.Handlers;

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
            _handlers = new HandlersContainer();
            _handlers.AddHandler(new UserHandler());

            _logger = new Logger("logs.txt", true);
        }

        public void Run()
        {
            try
            {
                _listener.Start();
                Console.WriteLine("Wait for connection...");

                while (true)
                {
                    TcpClient client = _listener.AcceptTcpClient();
                    _logger.Log("connection", client.Client.RemoteEndPoint?.ToString(), "");
                    Task.Run(async () => {
                        ClientObject clientObject = new ClientObject(client, _handlers, _logger);
                        await clientObject.Process();
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (_listener != null)
                    _listener.Stop();
            }
        }
    
    }
}
