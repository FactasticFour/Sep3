using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using PersistenceServer.Repository;

namespace PersistenceServer.Networking
{
    public class DataServer
    {
        private TcpListener listener;
        private IPAddress ipAddress;
        
        private RepositoryFactory repositoryFactory;

        public DataServer(RepositoryFactory repositoryFactory)
        {
            this.repositoryFactory = repositoryFactory;
        }

        public void Start()
        {
            ipAddress = IPAddress.Parse("127.0.0.1");
            listener = new TcpListener(ipAddress, 12345);
            listener.Start();

            while (true)
            {
                TcpClient acceptTcpClient = listener.AcceptTcpClient();
                ServerHandler serverHandler = new ServerHandler(acceptTcpClient, repositoryFactory);
                new Thread(() => handleClientConnection(serverHandler)).Start();
                Console.WriteLine("Server connected client");
            }
        }

        private void handleClientConnection(ServerHandler serverHandler)
        {
            serverHandler.HandleRequest();
        }
    }
}