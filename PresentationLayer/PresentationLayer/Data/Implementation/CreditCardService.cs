using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationLayer.Models;

namespace PresentationLayer.Data.Implementation
{
    public class CreditCardService : ICreditCardService
    {
        public async Task<bool> AddCreditCardToAccount(CreditCard creditCardFromPage)
        {
           
            HttpClient client = new HttpClient();
            String creditCard = JsonSerializer.Serialize(creditCardFromPage, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            Console.WriteLine(creditCard);
            HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:8080/creditcards/{creditCard}");
            
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