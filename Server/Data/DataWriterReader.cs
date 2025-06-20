

using System.Text.Json;

namespace Server.Data
{
    internal class DataWriterReader
    {
        private static object _locker = new();

        public static async Task SaveUsersToFile(string filename = "users.json")
        {
            List<UserData> users = UsersContainer.GetUsersList();

            string json = JsonSerializer.Serialize(users, new JsonSerializerOptions { IncludeFields = true });
            await File.WriteAllTextAsync(filename, json);

            Console.WriteLine(json);
        }

        public static async Task LoadUsers(string filename = "users.json")
        {
            List<UserData> users;

            string json = await File.ReadAllTextAsync(filename);

            users = JsonSerializer.Deserialize<List<UserData>>(json, new JsonSerializerOptions { IncludeFields = true }) ?? new List<UserData>();

            users.AsParallel().ForAll(user =>
            {
                UsersContainer.AddUser(user);
            });
        }

    }
}
