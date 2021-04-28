using System.Net;
using System.Net.Sockets;
using System.Threading;

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
                TcpClient acceptTcpClient = listener.AcceptTcpClient();
                ServerHandler serverHandler = new ServerHandler(acceptTcpClient);
                new Thread(() => handleClientConnection(serverHandler)).Start();
            }
        }

        private void handleClientConnection(ServerHandler serverHandler)
        {
            serverHandler.GetUserById();
        }
    }
}