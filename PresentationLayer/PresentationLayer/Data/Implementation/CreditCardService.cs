using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationLayer.Models;

namespace PresentationLayer.Data.Implementation
{
    public class CreditCardService : ICreditCardService
    {
        public async Task<bool> AddCreditCardToAccount(CreditCard creditCard)
        {
            HttpClient client = new HttpClient();
            String creditCard1 = JsonSerializer.Serialize(creditCard);
            HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:8080/creditcards/{creditCard1}");
            
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();

            bool ifAdded = JsonSerializer.Deserialize<bool>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            
            return ifAdded;
            
            
            
        }
    }
}