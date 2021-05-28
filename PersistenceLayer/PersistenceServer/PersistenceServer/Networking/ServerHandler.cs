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
            Request requestFromClient = new Request();

            try
            {
                string readFromStream = ReadFromStream();
                requestFromClient = ToObject<Request>(readFromStream);
                Console.WriteLine(requestFromClient.Payload);
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}Bytes from stream could not be read and converted to an Request Object");
                throw new IncompleteInitialization();
            }

            switch (requestFromClient.Type)
            {
                
                case Request.GET_USER_BY_ID:
                    User result = await RepositoryFactory.GetUserRepository().GetUserByIdAsync(ToObject<int>(requestFromClient.Payload));

                    string payload = ToJson(result);
                    Console.WriteLine(payload);
                    Reply reply = new Reply(Reply.SEND_USER, payload);
                    string toSendToClient = ToJson(reply);

                    SendToStream(toSendToClient);
                    break;
                case Request.SEED_DATABASE:
                    RepositoryFactory.GetDbSeedingRepository().SeedDatabase();
                    Reply seedingSuccessReply = new Reply(Reply.SEEDING_SUCCESS, null);
                    string toSend = ToJson(seedingSuccessReply);
                    
                    SendToStream(toSend);
                    break;
                case Request.ADD_CREDIT_CARD_TO_ACCOUNT:
                    try
                    {
                        await RepositoryFactory.GetCreditCardRepository()
                            .AddCreditCardToAccount(ToObject<CreditCard>(requestFromClient.Payload));
                        payload = ToJson("CARD_ADDED");
                        reply = new Reply(Reply.VERIFY_CREDIT_CARD_TO_ACCOUNT, payload);
                        toSendToClient = ToJson(reply);
                        SendToStream(toSendToClient);
                    }
                    catch (Exception e)
                    {
                        reply = new Reply(Reply.BAD_REQUEST, e.Message);
                        var json = ToJson(reply);
                        Console.WriteLine($"Reply with exception: {json}");
                        SendToStream(json);
                    }

                    break;
                default:
                    Reply badRequestReply = new Reply(Reply.BAD_REQUEST, "Bad Request");
                    String replySerialized = ToJson(badRequestReply);
                    SendToStream(replySerialized);
                    break;
            }
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