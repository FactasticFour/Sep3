using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationLayer.Models;
using PresentationLayer.Utils;

namespace PresentationLayer.Data.Implementation
{
    public class AccountService : IAccountService
    {
        public async Task<ViaEntity> CheckViaAccount(ViaEntity entityToCheck)
        {
            Console.WriteLine("writing to tier2");

            string hashedPassword = HashingUtils.GetHash(entityToCheck.Password);
            
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage =
                await client.GetAsync($"http://localhost:8080/account/verify?id={entityToCheck.ViaId}&password={hashedPassword}");

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