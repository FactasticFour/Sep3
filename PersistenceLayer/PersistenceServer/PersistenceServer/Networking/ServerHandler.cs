using System;
using System.Collections.Generic;
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
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e}Bytes from stream could not be read and converted to an Request Object");
                throw new IncompleteInitialization();
            }

            switch (requestFromClient.Type)
            {
                case Request.GET_USER_BY_ID:
                    User result = await RepositoryFactory.GetUserRepository()
                        .GetUserByIdAsync(ToObject<int>(requestFromClient.Payload));

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
                case Request.GET_ENTITY_WITH_ID:
                    await GetEntityWithId(requestFromClient);
                    break;
                case Request.GET_MEMBER_WITH_ID:
                    await GetMemberWithId(requestFromClient);
                    break;
                case Request.GET_FACILITY_WITH_ID:
                    await GetFacilityWithId(requestFromClient);
                    break;
                case Request.GET_ALL_ACCOUNT_TYPES:
                    await GEtAllAccountTypes();
                    break;
                case Request.GET_ROLE_WITH_TYPE:
                    await GetRoleWithType(requestFromClient);
                    break;
                case Request.GET_ACCOUNT_WITH_VIA_ID:
                    await GetAccountWithViaId(requestFromClient);
                    break;
                case Request.ADD_ACCOUNT:
                    await AddAccount(requestFromClient);
                    break;
                default:
                    Reply badRequestReply = new Reply(Reply.BAD_REQUEST, "Bad Request");
                    String replySerialized = ToJson(badRequestReply);
                    SendToStream(replySerialized);
                    break;
            }

            // TODO catching a bad request and passing it to the logic to handle it
            stream.Close();
        }

        private async Task AddAccount(Request requestFromClient)
        {
            await RepositoryFactory.GetAccountRepository()
                .AddAccountAsync(ToObject<Account>(requestFromClient.Payload));
            Console.WriteLine("back to server handler");
        }

        private async Task GetAccountWithViaId(Request requestFromClient)
        {
            try
            {
                Account account = await RepositoryFactory.GetAccountRepository()
                    .GetAccountWithViaId(ToObject<int>(requestFromClient.Payload));

                string accountAsString = ToJson(account);
                Reply accountReply = new Reply(Reply.SEND_ACCOUNT, accountAsString);

                SendToStream(ToJson(accountReply));
            }
            catch (Exception e)
            {
                Console.WriteLine("caught exception");
                Reply reply = new Reply("ERROR", ToJson($"{e.Message}"));
            }
            
        }

        private async Task GetRoleWithType(Request requestFromClient)
        {
            Role role = await RepositoryFactory.GetRoleRepository()
                .GetRoleWithTypeAsync(ToObject<string>(requestFromClient.Payload));

            string roleAsString = ToJson(role);
            Reply roleReply = new Reply(Reply.SEND_ROLE, roleAsString);

            SendToStream(ToJson(roleReply));
        }

        private async Task GEtAllAccountTypes()
        {
            List<string> allAccountTypes =
                await RepositoryFactory.GetRoleRepository().GetAllAccountTypesAsync();

            string allAccountTypesAsString = ToJson(allAccountTypes);
            Reply allAccountTypesReply = new Reply(Reply.SEND_ALL_ACCOUNT_TYPES, allAccountTypesAsString);

            SendToStream(ToJson(allAccountTypesReply));
        }

        private async Task GetFacilityWithId(Request requestFromClient)
        {
            Facility facility = await RepositoryFactory.GetFacilityRepository()
                .GetFacilityWithIdAsync(ToObject<int>(requestFromClient.Payload));

            string facilityAsString = ToJson(facility);
            Reply facilityReply = new Reply(Reply.SEND_FACILITY, facilityAsString);

            SendToStream(ToJson(facilityReply));
        }

        private async Task GetMemberWithId(Request requestFromClient)
        {
            Member member = await RepositoryFactory.GetMemberRepository()
                .GetMemberWithIdAsync(ToObject<int>(requestFromClient.Payload));

            string memberAsString = ToJson(member);
            Reply memberReply = new Reply(Reply.SEND_MEMBER, memberAsString);

            SendToStream(ToJson(memberReply));
        }

        private async Task GetEntityWithId(Request requestFromClient)
        {
            ViaEntity viaEntity = await RepositoryFactory.GetViaEntityRepository()
                .GetViaEntityWithIdAsync(ToObject<int>(requestFromClient.Payload));

            string viaEntityAsString = ToJson(viaEntity);
            Reply viaEntityReply = new Reply(Reply.SEND_ENTITY, viaEntityAsString);

            SendToStream(ToJson(viaEntityReply));
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