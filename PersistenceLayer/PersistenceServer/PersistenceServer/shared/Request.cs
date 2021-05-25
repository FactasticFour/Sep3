namespace PersistenceServer.shared
{
    public class Request
    {
        public const string  GET_USER_BY_ID = "GET_USER_BY_ID";
        public const string  SEED_DATABASE = "SEED_DATABASE";
        public const string  GET_MEMBER_BY_ID = "GET_MEMBER_BY_ID";
        public string Type { get; set; }
        public string Payload { get; set; }

        public Request(string type, string payload)
        {
            Type = type;
            Payload = payload;
        }

        public Request()
        {
        }
    }
}