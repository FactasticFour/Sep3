namespace PersistenceServer.shared
{
    public class Request
    {
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