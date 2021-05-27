namespace PersistenceServer.shared
{
    public class Request
    {
        public const string  GET_USER_BY_ID = "GET_USER_BY_ID";
        public const string  SEED_DATABASE = "SEED_DATABASE";
        public const string  GET_ENTITY_WITH_ID = "GET_ENTITY_WITH_ID";
        public const string  GET_MEMBER_WITH_ID = "GET_MEMBER_WITH_ID";
        public const string  GET_FACILITY_WITH_ID = "GET_FACILITY_WITH_ID";
        public const string  GET_ALL_ACCOUNT_TYPES = "GET_ALL_ACCOUNT_TYPES";
        public const string  GET_ROLE_WITH_TYPE = "GET_ROLE_WITH_TYPE";
        public const string  GET_ACCOUNT_WITH_VIA_ID = "GET_ACCOUNT_WITH_VIA_ID";
        public const string  ADD_ACCOUNT = "ADD_ACCOUNT";
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