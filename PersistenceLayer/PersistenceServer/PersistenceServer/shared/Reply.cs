namespace PersistenceServer.shared
{
    public class Reply
    {
        public const string SEND_USER = "SEND_USER";
        public const string BAD_REQUEST = "BAD_REQUEST";
        public const string SEEDING_SUCCESS = "SEEDING_SUCCESS";
        public const string VERIFY_CREDIT_CARD_TO_ACCOUNT = "VERIFY_CREDIT_CARD_TO_ACCOUNT";
        public const string CHECK_CREDIT_CARD_REPLY = "CHECK_CREDIT_CARD_REPLY";
        public const string DEPOSIT_MONEY_REPLY = "DEPOSIT_MONEY_REPLY";
        public string Type { get; set; }
        public string Payload { get; set; }

        public Reply(string type, string payload)
        {
            Type = type;
            Payload = payload;
        }
    }
}