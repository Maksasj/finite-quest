namespace FQ.Server
{
    public class RealmStatus
    {
        private readonly ILogger<RealmStatus> _logger;
        private readonly UserHandler _userHandler;

        public RealmStatus(ILogger<RealmStatus> logger, UserHandler userHandler) 
        { 
            _logger = logger;
            _userHandler = userHandler;
        }

        public RealmStatusMessage Status()
        {
            _logger.Log(LogLevel.Information, "Someone requested realm status");

            return new RealmStatusMessage
            {
                name = "Ursina",
                welcomeMessage = "Welcom to Ursina realm !",
                usersOnline = 0,
                userCount = _userHandler.GetUserCount()
            };
        }
    }
}
