namespace Server.Handlers
{
    internal class Logger
    {
        private static object _locker = new object();

        private string _fileName;
        private bool _consoleOutput;

        public Logger(string file_name, bool console_output = false)
        {
            _fileName = file_name;
            _consoleOutput = console_output;
        }

        public string LoggerFileName { get => _fileName; }

        public void EnableConsoleOutput() { lock(_locker) _consoleOutput = true; }
        public void DisableConsoleOutput() { lock (_locker) _consoleOutput = false; }

        public void Log(string message, string sender_endpoint, string username)
        {
            lock (_locker)
            {
                string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                string line = $"{timestamp} | {sender_endpoint} | {username} | {message}";
                File.AppendAllText(_fileName, line + Environment.NewLine);
                if (_consoleOutput)
                    Console.WriteLine(line);
            }
        }
    }
}
