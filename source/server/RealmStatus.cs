namespace FQ.Server
{
    public class RealmStatus
    {
        public RealmStatus() 
        { 
        }

        public RealmStatusMessage Status()
        {
            return new RealmStatusMessage
            {
                name = "Ursina",
                welcomeMessage = "Welcom to Ursina realm !",
                usersOnline = 0,
                userCount = 0
            };
        }
    }
}
