namespace PersistenceServer.shared
{
    public class Request
    {
        public RequestType Type { get; set; }
        public string Payload { get; set; }

        public Request(RequestType type, string payload)
        {
            Type = type;
            Payload = payload;
        }

        public Request()
        {
        }
    }
}