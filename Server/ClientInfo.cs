

using System.Net;

namespace Server
{
    internal class ClientInfo
    {
        private EndPoint _endPoint;
        private bool _authorized;
        private string? _login;

        public ClientInfo(EndPoint endPoint)
        {
            _endPoint = endPoint;
            _authorized = false;
            _login = null;
        }

        public string? RemoteEndPoint { get => _endPoint.ToString(); }
        public bool IsAuthorized { get => _authorized; } 
        public string? Login { get => _login?.Clone() as string; }

        public void SetAuthorization(string login)
        {
            _authorized = true;
            _login = login;
        }

    }
}
