using System.Text.Json;
using System.Text.Json.Serialization;

namespace FQ.Server
{
    public class UserHandler
    {
        private readonly ILogger<RealmStatus> _logger;
        private readonly string _backupFile;

        private UserContainer users;

        public UserHandler(ILogger<RealmStatus> logger)
        {
            _logger = logger;
            _backupFile = "userhandler.json";
            
            if (!File.Exists(_backupFile))
            {
                _logger.Log(LogLevel.Warning, "Users save do not exist");
                users = new UserContainer();
            } else {
                _logger.Log(LogLevel.Information, "Deserializing users save file");
                string jsonString = File.ReadAllText(_backupFile);
                users = JsonSerializer.Deserialize<UserContainer>(jsonString)!;
            }
        }

        public void AddUser(string name, PrivateKeyType privateKey)
        {
            _logger.Log(LogLevel.Information, "Added a new user to user handler");
            users.AddUser(new UserData
            {
                name = name,
                privateKey = privateKey,

                registrationTime = DateTime.UtcNow
            });

            Backup();
        }

        public void Backup()
        {
            JsonSerializerOptions options = new JsonSerializerOptions
            {
                WriteIndented = true,
                Converters =
                {
                    new JsonStringEnumConverter()
                }
            };

            string jsonString = JsonSerializer.Serialize(users, options);
            File.WriteAllText(_backupFile, jsonString);

            _logger.Log(LogLevel.Information, "Creating backup file of userhandler");
        }

        public bool IsUserExist(string username) => users.IsUserExist(username);

        public int GetUserCount() => users.GetUserCount();
    }
}
