using SpyCommunicationLib;
using System.Net;

namespace Server.Handlers
{
    internal interface IHandler
    {
        public bool CheckConditions(SpyMessage? message);

        public Task<string> HandleAsync(SpyMessage? message, EndPoint endPoint);
    }
}
