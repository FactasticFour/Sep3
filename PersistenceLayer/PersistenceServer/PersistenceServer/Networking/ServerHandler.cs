using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PersistenceServer.Data;
using PersistenceServer.Models;
using PersistenceServer.Repository;

namespace PersistenceServer.Networking
{
    public class ServerHandler
    {
        private TcpClient client;
        private NetworkStream stream;

        private IUserRepository repository;

        public ServerHandler(TcpClient client, IUserRepository repository)
        {
            this.client = client;
            stream = client.GetStream();
            this.repository = repository;
            //TODO Ask Troels dependency injection
        }

        public void AddUser()
        {
            if (stream.CanRead)
            {
                using DataContext dataContext = new DataContext();
                byte[] dataFromClient = new byte[1024];
                int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);
                Console.WriteLine(bytesRead);
                string userString = Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
                User user = JsonSerializer.Deserialize<User>(userString, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
                if (user != null)
                {
                    dataContext.Users.Add(user);
                }
            }
        }

        public void GetUserById()
        {
            byte[] dataFromClient = new byte[1024];
            int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);
            string userString = Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
            
            int intFromClient = JsonSerializer.Deserialize<int>(userString, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            User result = repository.GetUserByIdAsync(intFromClient).GetAwaiter().GetResult();

            Console.WriteLine(result);
            
            string toSendToClient = JsonSerializer.Serialize(result, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            byte[] bytesToSend = Encoding.ASCII.GetBytes(toSendToClient);
            stream.Write(bytesToSend);
            stream.Close();
        }

        // public void GetUserById()
        // {
        //     using DataContext dataContext = new DataContext();
        //     byte[] dataFromClient = new byte[1024];
        //     int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);
        //     string userString = Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
        //
        //     int intFromClient = JsonSerializer.Deserialize<int>(userString, new JsonSerializerOptions()
        //     {
        //         PropertyNameCaseInsensitive = true
        //     });
        //
        //     IQueryable<User> queryable = dataContext.Users.Where(user => user.UserId == intFromClient);
        //     User firstOrDefault = queryable.FirstOrDefault(user => user.UserId == intFromClient);
        //
        //     Console.WriteLine($"User found in db before serialization: {firstOrDefault.UserName}");
        //
        //     string toSendToClient = JsonSerializer.Serialize(firstOrDefault, new JsonSerializerOptions()
        //     {
        //         PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        //     });
        //
        //     byte[] bytesToSend = Encoding.ASCII.GetBytes(toSendToClient);
        //     stream.Write(bytesToSend);
        //     stream.Close();
        // }
    }
}