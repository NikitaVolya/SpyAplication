
using Server.Data;

namespace Server.ServerCommandLine
{
    public class AddUserCommand : Command
    {
        public AddUserCommand() : base("add_user", "Adds a new user to the server", new[] { "username", "password" })
        {

        }

        public override void Work(string text)
        {
            string[] options = ParseOptions(text);
            if (!CheckOptions(options))
                return;

            Task.Run(async () =>
            {
                bool result = await UsersContainer.AddUserAsync(options[0], options[1]);
                if (result)
                {
                    Console.WriteLine($"User '{options[0]}' added successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to add user '{options[0]}'. User may already exist or invalid data provided.");
                }
            }).Wait();
        }
    }

    public class DeleteUserCommand : Command
    {
        public DeleteUserCommand() : base("delete_user", "Delete user from server", new[] { "username" })
        {

        }

        public override void Work(string text)
        {
            string[] options = ParseOptions(text);
            if (!CheckOptions(options))
                return;

            Task.Run(async () =>
            {
                bool result = await UsersContainer.DeleteUserAsync(options[0]);
                if (result)
                {
                    Console.WriteLine($"User '{options[0]}' added successfully.");
                }
                else
                {
                    Console.WriteLine($"Failed to add user '{options[0]}'. User may already exist or invalid data provided.");
                }
            }).Wait();
        }
    }

    public class ListUsersCommand : Command
    {
        public ListUsersCommand() : base("list_users", "Lists all users on the server")
        {

        }

        public override void Work(string text)
        {
            var users = UsersContainer.GetUsersList();
            if (users.Count == 0)
            {
                Console.WriteLine("No users found.");
            }
            else
            {
                Console.WriteLine("Users on the server:");
                foreach (var user in users)
                {
                    Console.WriteLine($"- {user.Username}");
                }
            }
        }
    }
}
