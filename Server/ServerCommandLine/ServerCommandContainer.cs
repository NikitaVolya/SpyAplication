
namespace Server.ServerCommandLine
{

    public class ServerCommandContainer
    {
        // Зберігає всі доступні команди
        private List<Command> _commands = new List<Command>();
        private ServerCommandLine _commandLine;

        public ServerCommandContainer(ServerCommandLine commandLine)
        {
            _commandLine = commandLine;
        }

        //додає нову команду
        public void AddCommand(Command command)
        {
            _commands.Add(command);
        }

        // пошук по назві
        public Command FindCommand(string name)
        {
            return _commands.FirstOrDefault(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        //вивід всіх команд, з їх опціями та описом
        public void ShowAllCommands()
        {

            Console.WriteLine("Commands list:");
            foreach (var cmd in _commands)//перелік команд
            {
                string opts = string.Join(", ", cmd.Options);
                Console.WriteLine($"* {cmd.Name} [{opts}] — {cmd.Description}");

            }
            Console.WriteLine($"* quit [] — exit from command line");
            Console.WriteLine($"* exit [] — exit from command line");
        }

        //метод обробки та виконання команд приклад
        public void Work(string input)
        {

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("The input is empty. Type 'help' to see a list of commands.");
                return;
            }
            //виділення команди
            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length == 0) return;

            string commandName = parts[0];
            if (commandName == "help")
            {
                ShowAllCommands();
                return;
            } else if (commandName == "exit" || commandName == "quit")
            {
                Console.WriteLine("Exiting the command line.");
                _commandLine.Stop();
                return;
            }
            //пошук коианди
            var command = FindCommand(commandName);
            if (command == null)
            {
                Console.WriteLine($"Command '{commandName}' not found. Type 'help' to see a list of commands.");
                return;
            }
            //виконання команди
            command.Work(input);
        }
    }
}
