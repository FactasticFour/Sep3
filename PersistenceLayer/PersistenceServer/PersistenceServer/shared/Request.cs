namespace PersistenceServer.shared
{
    public class Request
    {
        public const string  GET_USER_BY_ID = "GET_USER_BY_ID";
        public const string  SEED_DATABASE = "SEED_DATABASE";
        public const string  GET_ENTITY_WITH_ID = "GET_ENTITY_WITH_ID";
        public const string  GET_ALL_ACCOUNT_TYPES = "GET_ALL_ACCOUNT_TYPES";
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