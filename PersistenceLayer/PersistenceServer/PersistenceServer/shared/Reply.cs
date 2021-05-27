namespace PersistenceServer.shared
{
    public class Reply
    {
        public const string  SEND_USER = "SEND_USER";
        public const string  BAD_REQUEST = "BAD_REQUEST";
        public const string  SEEDING_SUCCESS = "SEEDING_SUCCESS";
        public const string  SEND_ENTITY = "SEND_ENTITY";
        public const string  SEND_MEMBER = "SEND_MEMBER";
        public const string  SEND_FACILITY = "SEND_FACILITY";
        public const string  SEND_ALL_ACCOUNT_TYPES = "SEND_ALL_ACCOUNT_TYPES";
        public const string  SEND_ROLE = "SEND_ROLE";
        public const string  SEND_ACCOUNT = "SEND_ACCOUNT";
        public const string  ACCOUNT_CREATED = "ACCOUNT_CREATED";
        public string Type { get; set; }
        public string Payload { get; set; }

        public Reply(string type, string payload)
        {
            Type = type;
            Payload = payload;
        }
    }
}