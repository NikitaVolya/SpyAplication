
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

        private string _username;
        private string _password;


        public ClientObject(TcpClient client, HandlersContainer handlers)
        {
            _client = client;
            _handlers = handlers;
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
            return await _handlers.WorkAsync(message);
        }

        private async Task<bool> Connection(NetworkStream stream, byte[] buffer)
        {
            string connection_message = await ReadStream(stream, buffer);
            Console.WriteLine($"Connection message {connection_message}");

            SpyMessage? message = SpySerializer.DeserializeMessage(connection_message);

            bool authentication_check;
            ServerResponseDirector director = new ServerResponseDirector();
            SpyResponse<object> response;

            if (message is null)
            {
                // add check
                authentication_check = true;
                response = director.GetBadRequestResponse();
            } else
            {
                _username = message["username"];
                _password = message["password"];

                authentication_check = true;
                // Add authentication check
                if (authentication_check)
                {
                    response = director.GetAuthorizationSuccessResponse("");
                }
                else
                {
                    response = director.GetUnauthorizedResponse();
                }
            }
            Console.WriteLine(response);
            await SendStream(stream, buffer, SpySerializer.SerializeResponse(response));
            return authentication_check;
        }

        public async Task Process()
        {
            NetworkStream stream = _client.GetStream();
            byte[] buffer = new byte[64];


            string client_endpoint = _client.Client.RemoteEndPoint.ToString();

            if (!(await Connection(stream, buffer)))
            {
                stream?.Close();
                _client?.Close();
                Console.WriteLine("Refuse connection");
                return;
            }

            try
            {
                string response, message;

                while (true)
                {
                    message = await ReadStream(stream, buffer);
                    SpyMessage? messageObject = SpySerializer.DeserializeMessage(message);

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
