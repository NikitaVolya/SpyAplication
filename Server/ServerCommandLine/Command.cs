using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.ServerCommandLine
{
    public class Command
    {
        // Поля
        private string _name;
        private string[] _options;
        private string _description;

        // поверта тільки _name без можливості його змінити
        public string Name => _name;

        public string Description => _description;

        public string[] Options => _options.ToArray();

        // Конструктор
        public Command(string name, string description, string[] options = null)
        {
            _name = name;
            _description = description;
            _options = options ?? new string[0];
        }

        // метод для виконання команди
        public virtual void Work(string text)
        {

        }

        // Бере команду та повертає введені опції
        private string[] GetOptions(string text)
        {
            // Розділити текст на частини
            string[] parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            // перше слово — це команда, друге слово це опції
            if (parts.Length <= 1)
                return new string[0];

            return parts.Skip(1).ToArray();
        }

        // Додатковий метод для доступу до опцій ззовні 
        protected string[] ParseOptions(string text)
        {
            _options = GetOptions(text);
            return _options;
        }

        protected bool CheckOptions(string[] options)
        {
            if (_options.Length != options.Length)
            {
                Console.WriteLine($"Error: Command {_name} expected {options.Length} options, but got {_options.Length}.");
                return false;
            }
            return true;
        }
    }

}
