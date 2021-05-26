using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PresentationLayer.Data.Implementation
{
    public class AccountService : IAccountService
    {
        public async Task<float> getAccountBalance(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:8080/account/{id}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();

            float balance = JsonSerializer.Deserialize<float>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return balance;
        }
    }
}