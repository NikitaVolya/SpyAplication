using SpyCommunicationLib;
using SpyCommunicationLib.Directors;

namespace Server.Handlers
{
    internal class HandlersContainer
    {
        private List<IHandler> _handlers;

        public HandlersContainer()
        {
            _handlers = new List<IHandler>();
        }

        public void AddHandler(IHandler handler)
        {
            _handlers.Add(handler);
        }

        public async Task<string> WorkAsync(SpyMessage? message)
        {
            Console.WriteLine(message?.ToString());

            foreach (var handler in _handlers)
            {
                if (!handler.CheckConditions(message))
                    continue;
                return await handler.HandleAsync(message);
            }

            ServerResponseDirector director = new ServerResponseDirector();
            return director.GetNotFoundRequestResponse().ToString();
        }
    }
}
