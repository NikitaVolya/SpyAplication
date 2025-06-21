

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
        }

        private static async Task<string?> LoadFromFile(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File {filename} not found, creating a new one.");
                return null;
            }
            return await File.ReadAllTextAsync(filename);
        }

        public static async Task SaveRecordsToFile(string filename = "records.json")
        {
            List<RecordData> records = RecordsContainer.GetRecordsList();

            string json = JsonSerializer.Serialize(records, new JsonSerializerOptions { IncludeFields = true });
            await File.WriteAllTextAsync(filename, json);
        }

        public static async Task LoadUsersAsync(string filename = "users.json")
        {

            string? json = await LoadFromFile(filename);
            if (json == null || json == string.Empty)
                return;

            List<UserData> users = JsonSerializer.Deserialize<List<UserData>>(json, new JsonSerializerOptions { IncludeFields = true }) ?? new List<UserData>();

            users
            .AsParallel()
            .ForAll(async user =>
            {
                await UsersContainer.AddUserAsync(user);
            });
        }

        public static async Task LoadRecordsAsync(string filename = "records.json")
        {
            string? json = await LoadFromFile(filename);
            if (json == null || json == string.Empty)
                return;

            List<RecordData> records = JsonSerializer.Deserialize<List<RecordData>>(json, new JsonSerializerOptions { IncludeFields = true }) ?? new List<RecordData>();

            records
                .AsParallel()
                .ForAll(async record =>
                {
                    await RecordsContainer.AddRecordAsync(record);
                });
        }
    }
}
