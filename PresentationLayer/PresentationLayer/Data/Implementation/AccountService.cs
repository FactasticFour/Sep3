using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PresentationLayer.Models;
using PresentationLayer.Utils;

namespace PresentationLayer.Data.Implementation
{
    public class AccountService : IAccountService
    {
        public async Task<ViaEntity> CheckViaAccountAsync(ViaEntity entityToCheck)
        {
            Console.WriteLine("writing to tier2");

            string hashedPassword = HashingUtils.GetHash(entityToCheck.Password);
            
            HttpClient client = new HttpClient();
            HttpResponseMessage responseMessage =
                await client.GetAsync($"http://localhost:8080/account?id={entityToCheck.ViaId}&password={hashedPassword}");

            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($"Error: {responseMessage.StatusCode}, {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            Console.WriteLine(result);

            ViaEntity viaEntity;

            if (result.Contains("cpr"))
            {
                viaEntity = JsonSerializer.Deserialize<Member>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }
            else
            {
                viaEntity = JsonSerializer.Deserialize<Facility>(result, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
            }

            Console.WriteLine(viaEntity);
            return viaEntity;
        }

        public async Task<Role> CreateAccountAsync(Role role)
        {
            Role roleToSend = role;
            //roleToSend.Account.ApplicationPassword = HashingUtils.GetHash(role.Account.ApplicationPassword);

            HttpClient client = new HttpClient();

            string roleAsJson = JsonSerializer.Serialize(roleToSend);

            Console.WriteLine(roleAsJson);

            StringContent content = new StringContent(
                roleAsJson,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage responseMessage = await client.PostAsync("http://localhost:8080/account", content);

            if (!responseMessage.IsSuccessStatusCode)
            {
                return null;
            }
            else
            {
                return role;
            }
        }
    }
    
    
}