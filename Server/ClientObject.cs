
using Server.Handlers;
using SpyCommunicationLib;
using SpyCommunicationLib.Directors;
using System.Net.Sockets;
using System.Text;

namespace Server
{
    internal class ClientObject
    {
        private TcpClient _client;
        private readonly HandlersContainer _handlers;

        private ClientInfo _clientInfo;


        public ClientObject(TcpClient client, HandlersContainer handlers)
        {
            if (client  == null) 
                throw new ArgumentNullException("client");

            _client = client;
            _handlers = handlers;
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
            Console.WriteLine("Send ", text);
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

                    Console.WriteLine("Request {0} : {1}", _clientInfo.RemoteEndPoint, messageObject);

                    response = await ServerLogic(messageObject);

                    await SendStream(stream, buffer, response);
                }
            }
            catch (Exception ex)
            {
                // Add log if error
            }
            finally
            {
                stream?.Close();
                _client?.Close();
            }
        }
    }
}
