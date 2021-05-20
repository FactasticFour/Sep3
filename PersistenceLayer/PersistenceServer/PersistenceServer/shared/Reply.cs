namespace PersistenceServer.shared
{
    public class Reply
    {
        public ReplyType Type { get; set; }
        public string Payload { get; set; }

        public Reply(ReplyType type, string payload)
        {
            Type = type;
            Payload = payload;
        }
    }
}