namespace FQ.Server
{
    [Serializable]
    public class UserData
    {
        public string name { get; set; }
        public PrivateKeyType privateKey { get; set; }

        public DateTime registrationTime { get; set; }
    }
}
