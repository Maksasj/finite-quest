namespace FQ.Server
{
    [Serializable]
    public class UserContainer
    {
        public Dictionary<string, UserData> _users { get; set; }

        public UserContainer()
        {
            _users = new Dictionary<string, UserData>();
        }

        public bool IsUserExist(string username)
        {
            bool exists = false;

            foreach (var user in _users)
                if (user.Value.name == username)
                    exists = true;

            return exists;
        }

        public int GetUserCount() => _users.Count;
        public void AddUser(UserData user) => _users.Add(user.privateKey.value, user);
    }
}
