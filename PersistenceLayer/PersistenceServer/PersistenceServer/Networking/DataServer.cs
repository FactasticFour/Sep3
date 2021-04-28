using System.Net;
using System.Net.Sockets;

namespace PersistenceServer.Networking
{
    public class DataServer
    {
        private NetworkStream networkStream;
        private TcpListener listener;
        private IPAddress ipAddress;

        public void Start()
        {
            ipAddress = IPAddress.Parse("127.0.0.1");
            listener = new TcpListener(ipAddress, 12345);
            listener.Start();

            while (true)
            {
                
            }
        }


    }
}