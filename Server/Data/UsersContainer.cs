

namespace Server.Data
{
    class UserData
    {
        public string? Username;
        public string? Password;
    }

    class UsersContainer
    {
        private static List<UserData> _users = new List<UserData>();
        private static object _locker = new();


        private static UserData? GetUserOrDefault(string username)
        {
            return _users
                .AsParallel()
                .Where(u => u.Username == username)
                .FirstOrDefault();
        }

        public static bool UserExiste(string username)
        {
            return GetUserOrDefault(username) != null;
        }

        public static bool AddUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return false;

            if (UserExiste(username))
                return false;

            lock (_locker)
                _users.Add(new UserData {Username = username, Password = password});

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
