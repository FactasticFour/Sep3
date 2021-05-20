using System;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.VisualBasic.CompilerServices;
using PersistenceServer.Data;
using PersistenceServer.Models;
using PersistenceServer.Repository;
using PersistenceServer.shared;

namespace PersistenceServer.Networking
{
    public class ServerHandler
    {
        private NetworkStream stream;

        public ServerHandler(TcpClient client)
        {
            stream = client.GetStream();
        }

        public async Task HandleRequest()
        {
            // TODO consider making a bad request 
            Request requestFromClient = new Request()
            {
                Type = "Bad Request",
                Argument = "No Argument"
            };
            
            try
            {
                string readFromStream = ReadFromStream();
                requestFromClient = ToObject<Request>(readFromStream);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}Bytes from stream could not be read and converted to an Request Object");
                throw new IncompleteInitialization();
            }

            switch (requestFromClient.Type)
            {
                case "getUserById":
                    User result = await RepositoryFactory.GetUserRepository().GetUserByIdAsync(ToObject<int>(requestFromClient.Argument));
                    string toSendToClient = ToJson(result);
                    SendToStream(toSendToClient);
                    break;
                case "seedDatabase":
                    RepositoryFactory.GetDbSeedingRepository().SeedDatabase();
                    break;
                case "addCreditCardToAccount":
                    await RepositoryFactory.GetCreditCardRepository()
                        .AddCreditCardToAccount(ToObject<CreditCard>(requestFromClient.Argument));
                    break;
            }
            // TODO catching a bad request and passing it to the logic to handle it
            stream.Close();
        }

        private string ReadFromStream()
        {
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