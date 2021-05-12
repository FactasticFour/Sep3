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

        public void HandleRequest()
        {
            string readFromStream = ReadFromStream();
            Request requestFromClient = ToObject<Request>(readFromStream);

            switch (requestFromClient.Type)
            {
                case "getUserById":
                    User result = repository.GetUserByIdAsync(ToObject<int>((JsonElement) requestFromClient.Argument))
                        .GetAwaiter().GetResult();

                    string toSendToClient = ToJson(result);
                    SendToStream(toSendToClient);
                    break;
            }

            stream.Close();
        }

        private string ReadFromStream()
        {
            //TODO exception
            byte[] dataFromClient = new byte[1024];
            int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);
            return Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
        }

        private void SendToStream(string toSendToClient)
        {
            byte[] bytesToSend = Encoding.ASCII.GetBytes(toSendToClient);
            stream.Write(bytesToSend);
        }

        // overloaded methods for deserialization of common objects
        private T ToObject<T>(JsonElement element)
        {
            var json = element.GetRawText();
            Console.WriteLine($"--{json}");
            var deserializeResult = JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            Console.WriteLine($"--{deserializeResult}");
            return deserializeResult;
        }

        private T ToObject<T>(String element)
        {
            var deserializeResult = JsonSerializer.Deserialize<T>(element, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return deserializeResult;
        }

        private string ToJson<T>(T objToSerialize)
        {
            string serialized = JsonSerializer.Serialize(objToSerialize, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });

            return serialized;
        }
    }
}