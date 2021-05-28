namespace PersistenceServer.shared
{
    public class Request
    {
        public const string  GET_USER_BY_ID = "GET_USER_BY_ID";
        public const string  SEED_DATABASE = "SEED_DATABASE";
        public const string  ADD_CREDIT_CARD_TO_ACCOUNT = "ADD_CREDIT_CARD_TO_ACCOUNT";
        public const string CHECK_CREDIT_CARD = "CHECK_CREDIT_CARD";
        public const string DEPOSIT_MONEY = "DEPOSIT_MONEY";

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