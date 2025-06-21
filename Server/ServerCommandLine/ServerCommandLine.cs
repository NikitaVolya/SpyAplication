

namespace Server.ServerCommandLine
{
    public class ServerCommandLine
    {
        private ServerCommandContainer _commandContainer;
        private bool _isRunning = false;

        public ServerCommandLine()
        {
            _commandContainer = new ServerCommandContainer(this);
            _commandContainer.AddCommand(new AddUserCommand());
            _commandContainer.AddCommand(new DeleteUserCommand());
            _commandContainer.AddCommand(new ListUsersCommand());
        }

        public bool IsRunning => _isRunning;

        public void Start()
        {
            _isRunning = true;
            Console.WriteLine("Server Command Line started. Type 'help' to see available commands.");
            while (_isRunning)
            {
                Console.Write("> ");
                string? input = Console.ReadLine();
                if (input == null) continue;

                // Обробка команди
                _commandContainer.Work(input);
            }
        }

        public void Stop()
        {
            _isRunning = false;
        }
    }
}
