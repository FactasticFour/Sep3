namespace PersistenceServer.shared
{
    public class Request
    {
        public string Type { get; set; }
        public string Argument { get; set; }

        public Request(string type, string argument)
        {
            Type = type;
            Argument = argument;
        }

    }
}