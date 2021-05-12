using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PersistenceServer.Data;
using PersistenceServer.Models;
using PersistenceServer.Repository;
using PersistenceServer.shared;

namespace PersistenceServer.Networking
{
    public class ServerHandler
    {
        private NetworkStream stream;

        private IUserRepository repository;

        public ServerHandler(TcpClient client)
        {
            stream = client.GetStream();
            repository = new UserRepositoryImpl();
        }

        public void PerformRequest()
        {
            string requestAsString = ReadFromStream();

            Request requestFromClient = JsonSerializer.Deserialize<Request>(requestAsString, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });

            String requestType = requestFromClient.Type;
            //TODO Possible null exception
            
            if (requestType.Equals("getUserById"))
            {
                 int id = JsonSerializer.Deserialize<int>(requestFromClient.Argument, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
                 
                 User result = repository.GetUserByIdAsync(id).GetAwaiter().GetResult();
                 
                 string toSendToClient = JsonSerializer.Serialize(result, new JsonSerializerOptions()
                 {
                     PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                 });
                 
                 SendToStream(toSendToClient);
            }
            else
            {
                throw new Exception("id is null");
            }
            
            stream.Close();
        }

        private string ReadFromStream()
        {
            //TODO exception? maybe, hopefully not
            byte[] dataFromClient = new byte[1024];
            int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);
            return Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
        }

        private void SendToStream(string toSendToClient)
        {
            //TODO exception
            byte[] bytesToSend = Encoding.ASCII.GetBytes(toSendToClient);
            stream.Write(bytesToSend);
        }

        // we can use it for deserialization of common objects
        private T ToObject<T>(JsonElement element)
        {
            var json = element.GetRawText();
            var deserializeResult = JsonSerializer.Deserialize<T>(json);
            return deserializeResult;
            
        }
        
    }
}