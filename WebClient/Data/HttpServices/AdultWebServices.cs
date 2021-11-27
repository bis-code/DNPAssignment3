using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace WebClient.Data.HttpServices
{
    public class AdultWebServices : IAdultServices
    {
        private string uri = "https://localhost:5001";

        private readonly HttpClient client;

        public AdultWebServices()
        {
            client = new HttpClient();
        }
        
        public async Task<IList<Adult>> GetAllAdultsAsync(int familyId)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Adults");
            string message = await stringAsync;
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task<Adult> GetAdultAsync(int id)
        {
            Task<string> stringAsync = client.GetStringAsync($"{uri}/Adults/{id}");
            string message = await stringAsync;
            Adult result = JsonSerializer.Deserialize<Adult>(message);
            return result;
        }

        public async Task AddAdultAsync(Adult adult)
        {
            adult.Photo = "default.png";
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/Adults", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine("CLient > Successfully adult added.");
            }
        }

        public async Task<Adult> RemoveAdultAsync(int id)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync($"{uri}/Adults/{id}");
            string reply = await responseMessage.Content.ReadAsStringAsync();

            Adult removedAdult = JsonSerializer.Deserialize<Adult>(reply);

            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                return removedAdult;
            }

            return null;
        }

        public async Task UpdateAdultAsync(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson,
                Encoding.UTF8,
                "application/json");
            var response = await client.PutAsync($"{uri}/Adults", content);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.ReasonPhrase);
            }
            
        }
    }
}