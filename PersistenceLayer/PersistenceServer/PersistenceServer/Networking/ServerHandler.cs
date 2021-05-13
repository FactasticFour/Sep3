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
        private RepositoryFactory repositoryFactory;

        public ServerHandler(TcpClient client, RepositoryFactory repositoryFactory)
        {
            stream = client.GetStream();
            this.repositoryFactory = repositoryFactory;
        }

        public async Task HandleRequest()
        {
            string readFromStream = ReadFromStream();
            Request requestFromClient = ToObject<Request>(readFromStream);

            switch (requestFromClient.Type)
            {
                case "getUserById":
                    User result = await repositoryFactory.GetUserRepository().GetUserByIdAsync(ToObject<int>(requestFromClient.Argument));
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