using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace PresentationLayer.Data.Implementation
{
    public class CreditCardService : ICreditCardService
    {
        public async Task<bool> CheckCreditCard(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:8080/creditcard/{id}");
            
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            
            bool response = JsonSerializer.Deserialize<bool>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return response;

        }

        public Task DepositMoney(float amount)
        {
            throw new System.NotImplementedException();
        }
    }
}