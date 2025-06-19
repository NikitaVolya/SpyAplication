
using Server.Handlers;
using SpyCommunicationLib;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class ClientObject
    {
        private TcpClient _client;
        private readonly Logger _logger;
        private readonly HandlersContainer _handlers;

        private ClientInfo _clientInfo;


        public ClientObject(TcpClient client, HandlersContainer handlers, Logger logger)
        {
            if (client  == null) 
                throw new ArgumentNullException("client");

            _client = client;
            _handlers = handlers;
            _logger = logger;
            _clientInfo = new ClientInfo(client.Client.RemoteEndPoint);
        }

        private static async Task<string> ReadStream(NetworkStream stream, byte[] buffer)
        {
            StringBuilder builder = new StringBuilder();
            int bytes = 0;
            do
            {
                bytes = await stream.ReadAsync(buffer, 0, buffer.Length);
                builder.Append(Encoding.Unicode.GetString(buffer, 0, bytes));
            }
            while (stream.DataAvailable);

            return builder.ToString();
        }

        private static async Task SendStream(NetworkStream stream, byte[] data, string text)
        {
            data = Encoding.Unicode.GetBytes(text);
            await stream.WriteAsync(data, 0, data.Length);
        }

        private async Task<string> ServerLogic(SpyMessage? message)
        {
            return await _handlers.WorkAsync(message, _clientInfo);
        }

        public async Task Process()
        {
            NetworkStream stream = _client.GetStream();
            byte[] buffer = new byte[64];

            try
            {
                string response, message;

                while (true)
                {

                    message = await ReadStream(stream, buffer);
                    SpyMessage? messageObject = SpySerializer.DeserializeMessage(message);
                    Console.WriteLine(messageObject);
                    _logger.Log(_clientInfo.RemoteEndPoint ?? "nan", messageObject?.Action.ToString() ?? "Unknown command", _clientInfo.Login ?? "guest");

                    response = await ServerLogic(messageObject);
                    await SendStream(stream, buffer, response);
                }
            }
            catch (Exception ex)
            {
                _logger.Log(_clientInfo.RemoteEndPoint ?? "nan", ex.ToString(), _clientInfo.Login ?? "guest");
            }
            finally
            {
                stream?.Close();
                _client?.Close();
                _logger.Log(_clientInfo.RemoteEndPoint ?? "nan", "close connection", _clientInfo.Login ?? "guest");
            }
        }
    }
}
