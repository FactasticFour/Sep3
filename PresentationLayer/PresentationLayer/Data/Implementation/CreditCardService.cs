using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using PresentationLayer.Models;

namespace PresentationLayer.Data.Implementation
{
    public class CreditCardService : ICreditCardService
    {
        public async Task<string> AddCreditCardToAccount(CreditCard creditCardFromPage)
        {
           
            HttpClient client = new HttpClient();
            String creditcard = JsonSerializer.Serialize(creditCardFromPage, new JsonSerializerOptions()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            });
            Uri u = new Uri("http://localhost:8080/creditcards/addcreditcard");
            HttpContent c = new StringContent(creditcard, Encoding.UTF8, "application/json");
            
            
            HttpResponseMessage response = await client.PostAsync(u, c);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"{response.Content.ReadAsStringAsync().Result}");
            }
            
            return "Card Added Successfully!";
        }
    }
}