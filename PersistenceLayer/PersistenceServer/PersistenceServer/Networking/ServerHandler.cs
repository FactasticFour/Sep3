using System;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using PersistenceServer.Data;
using PersistenceServer.Models;

namespace PersistenceServer.Networking
{
    public class ServerHandler
    {
        private TcpClient client;
        private NetworkStream stream;
        private DataContext context;

        public ServerHandler(TcpClient client)
        {
            this.client = client;
            stream = client.GetStream();
        }

        public void AddUser()
        {
            if (stream.CanRead)
            {
                byte[] dataFromClient = new byte[1024];
                int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);
                string userString = Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
                User user = JsonSerializer.Deserialize<User>(userString, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
                if (user != null)
                {
                    context.Users.Add(user);
                }
            }
        }
    }
}