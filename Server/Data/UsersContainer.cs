

namespace Server.Data
{
    class UserData : ICloneable
    {
        public string? Username;
        public string? Password;

        public object Clone()
        {
            return new UserData
            {
                Username = this.Username,
                Password = this.Password
            };
        }
    }

    class UsersContainer
    {
        private static List<UserData> _users = new List<UserData>();
        private static object _locker = new();

        public static UserData? GetUserOrDefault(string username)
        {
            lock (_locker)
                return _users
                    .AsParallel()
                    .Where(u => u.Username == username)
                    .FirstOrDefault();
        }

        public static List<UserData> GetUsersList()
        {
            lock (_locker)
                return _users.AsParallel().Select(u => (UserData)u.Clone()).ToList();
        }

        public static bool UserExiste(string username)
        {
            return GetUserOrDefault(username) != null;
        }

        public static async Task<bool> AddUserAsync(string username, string password)
        {
            return await AddUserAsync(new UserData
            {
                Username = username,
                Password = password
            });
        }

        public static async Task<bool> DeleteUserAsync(string username)
        {
            UserData? userData = GetUserOrDefault(username);
            if (userData == null)
                return false;
            _users.Remove(userData);
            return true;
        }

        public static async Task<bool> AddUserAsync(UserData userData)
        {
            if (string.IsNullOrEmpty(userData.Username) || string.IsNullOrEmpty(userData.Password))
                return false;

            if (UserExiste(userData.Username))
                return false;

            lock (_locker)
                _users.Add(userData);

            return true;
        }

        public static bool UserCheck(string username, string password)
        {
            UserData? userData = GetUserOrDefault(username);
            if (userData == null)
                return false;

            return userData.Password == password;
        }
    }
}
