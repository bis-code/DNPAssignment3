using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace WebClient.Data.HttpServices
{
    public class PetWebServices : IPetServices
    {
        private string uri = "https://localhost:5001";

        private readonly HttpClient client;

        public PetWebServices()
        {
            client = new HttpClient();
        }
        
        public async Task<IList<Pet>> GetAllPetsAsync(int childId)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Pets");
            string message = await stringAsync;
            List<Pet> result = JsonSerializer.Deserialize<List<Pet>>(message);
            return result;
        }

        public async Task<Pet> GetPetAsync(int id)
        {
            Task<string> stringAsync = client.GetStringAsync($"{uri}/Pets/{id}");
            string message = await stringAsync;
            Pet result = JsonSerializer.Deserialize<Pet>(message);
            return result;
        }

        public async Task AddPetAsync(Pet pet)
        {
            string petAsJson = JsonSerializer.Serialize(pet);
            HttpContent content = new StringContent(petAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/Pets", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine("CLient > Successfully pet added.");
            }
        }

        public async Task<Pet> RemovePetAsync(int id)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync($"{uri}/Pets/{id}");
            string reply = await responseMessage.Content.ReadAsStringAsync();

            Pet removePet = JsonSerializer.Deserialize<Pet>(reply);

            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                return removePet;
            }

            return null;
        }

        public async Task UpdatePetAsync(Pet pet)
        {
            string petAsJson = JsonSerializer.Serialize(pet);
            HttpContent content = new StringContent(petAsJson,
                Encoding.UTF8,
                "application/json");
            var response = await client.PutAsync($"{uri}/Pets", content);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.ReasonPhrase);
            }
            
        }
    }
}