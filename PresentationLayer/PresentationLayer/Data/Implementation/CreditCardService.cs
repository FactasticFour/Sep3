using System;
using System.Net.Http;
using System.Text;
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
            HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:8080/creditcard/addcredit/{creditCard}");
            
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            Console.WriteLine("it got to service after response status code");
            
            string result = await responseMessage.Content.ReadAsStringAsync();

            bool ifAdded = JsonSerializer.Deserialize<bool>(result, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            Console.WriteLine("it got deserialized");
            
            return ifAdded;
        }
        
        public async Task<bool> CheckCreditCard(int id)
            {
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync($"http://localhost:8080/creditcard/checkcreditcard/{id}");

            Console.WriteLine("it got here");
            
                if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }
                
            string result = await responseMessage.Content.ReadAsStringAsync();

            Console.WriteLine("Response got to service");
            
            bool response = JsonSerializer.Deserialize<bool>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            Console.WriteLine("response deserialized");
                return response;
            }
        
            public async Task<bool> DepositMoney(Account account)
            {
                HttpClient client = new HttpClient();
                string todoAsJson = JsonSerializer.Serialize(account, new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });
                HttpContent content = new StringContent(todoAsJson,
                    Encoding.UTF8,
                    "application/json");
                HttpResponseMessage responseMessage =
                    await client.PatchAsync("http://localhost:8080/creditcard/depositmoney", content);
                
                 if (!responseMessage.IsSuccessStatusCode)
                 {
                     throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
                 }
                
                string result = await responseMessage.Content.ReadAsStringAsync();

                bool response = JsonSerializer.Deserialize<bool>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                Console.WriteLine("response deserialized");
                return response;
                

            }
        
    }
    
    
}