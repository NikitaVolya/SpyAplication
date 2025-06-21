using SpyCommunicationLib;
using SpyCommunicationLib.Directors;
using System.Net.Sockets;
using System.Text;

namespace SpyClient
{
    public class SpyClient
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private readonly SpyMessageDirector _director = new SpyMessageDirector();

        private const string _host = "127.0.0.1";
        private const int _port = 8888;

        public bool IsConnected => _client?.Connected ?? false;

        public async Task<bool> ConnectAsync()
        {
            try
            {
                _client = new TcpClient();
                await _client.ConnectAsync(_host, _port);
                _stream = _client.GetStream();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SpyClient] Connection failed: {ex.Message}");
                return false;
            }
        }

        public async Task SendKeysAsync(List<int> keys)
        {
            if (!IsConnected)
            {
                Console.WriteLine("[SpyClient] Not connected to server.");
                return;
            }

            SpyMessage message = _director.GetSendDataMessage(keys);
            string json = message.ToString();

            byte[] data = Encoding.Unicode.GetBytes(json);
            await _stream.WriteAsync(data, 0, data.Length);
        }

        public async Task<SpyResponse<object>?> GetResponseAsync()
        {
            if (!IsConnected)
            {
                Console.WriteLine("[SpyClient] Not connected to server.");
                return null;
            }

            byte[] buffer = new byte[4096];
            int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
            string responseString = Encoding.Unicode.GetString(buffer, 0, bytesRead);

            try
            {
                var response = SpySerializer.DeserializeResponse<object>(responseString);
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SpyClient] Failed to parse response: {ex.Message}");
                return null;
            }
        }

        public void Disconnect()
        {
            _stream?.Close();
            _client?.Close();
        }
    }
}