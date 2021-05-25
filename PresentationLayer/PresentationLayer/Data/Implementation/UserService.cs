using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationLayer.Models;

namespace PresentationLayer.Data.Implementation
{
    public class UserService : IUserService
    {
        public async Task<User> GetUserByIdAsync(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:8080/users/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();

            User user = JsonSerializer.Deserialize<User>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return user;
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