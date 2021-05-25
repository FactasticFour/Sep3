using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationLayer.Models;

namespace PresentationLayer.Data.Implementation
{
    public class LoginService : ILoginService
    {
        public async Task<Account> ValidateAccountAsync(string username, string passwordHashed)
        {
            Console.WriteLine($"{username} + {passwordHashed}");
            HttpClient client = new HttpClient();

            HttpResponseMessage response =
                await client.GetAsync($"http://localhost:8080/users?password={username}&username={passwordHashed}");
            
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {response.StatusCode}, {response.ReasonPhrase}");
            }
            
            string result = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"result before deserialization: {result}");
            Account account = ToObject<Account>(result);
            Console.WriteLine($"Account received: {account.AccountType.RoleType}");
            // TODO handle rainy scenario
            return account;
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