using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationLayer.Models;

namespace PresentationLayer.Data.Implementation
{
    public class AccountService : IAccountService
    {
        public async Task<ViaEntity> CheckViaAccount(int id, string password)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage =
                await client.GetAsync($"http://localhost:8080/account/verify?id={id}&password={password}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();

            ViaEntity viaEntity = JsonSerializer.Deserialize<ViaEntity>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return viaEntity;
        }
    }
    
    
}