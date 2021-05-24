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
            Request requestFromClient = new Request()
            {
                Payload = "",
                Type = ""
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
                
                case "GET_USER_BY_ID":
                    User result = await RepositoryFactory.GetUserRepository().GetUserByIdAsync(ToObject<int>(requestFromClient.Payload));

                    string payload = ToJson(result);
                    Reply reply = new Reply("SEND_USER", payload);
                    string toSendToClient = ToJson(reply);
                    SendToStream(toSendToClient);
                    break;
                case "SEED_DATABASE":
                    RepositoryFactory.GetDbSeedingRepository().SeedDatabase();
                    break;
                case "getViaEntityById":
                    Console.WriteLine("--server handler--");
                    ViaEntity viaEntity = await RepositoryFactory.GetAccountRepository()
                        .GetViaEntityByIdAsync(ToObject<int>(requestFromClient.Argument));
                    string viaEntityAsString = ToJson(viaEntity);
                    Console.WriteLine(viaEntityAsString);
                    SendToStream(viaEntityAsString);
                    break;
                case "getViaMemberById":
                    Member viaMember = await RepositoryFactory.GetAccountRepository()
                        .GetViaMemberByIdAsync(ToObject<int>(requestFromClient.Argument));

                    string viaMemberAsString = ToJson(viaMember);
                    Console.WriteLine(viaMemberAsString);
                    SendToStream(viaMemberAsString);
                    break;
                case "getViaFacilityById":
                    Facility viaFacility = await RepositoryFactory.GetAccountRepository()
                        .GetViaFacilityByIdAsync(ToObject<int>(requestFromClient.Argument));

                    string viaFacilityAsString = ToJson(viaFacility);
                    Console.WriteLine(viaFacilityAsString);
                    SendToStream(viaFacilityAsString);
                    break;
                default:
                    Reply badRequestReply = new Reply("BAD_REQUEST", "Bad Request");
                    String replySerialized = ToJson(badRequestReply);
                    SendToStream(replySerialized);
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