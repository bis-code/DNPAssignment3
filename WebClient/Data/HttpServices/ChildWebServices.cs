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
    public class ChildWebServices : IChildServices
    {
        private string uri = "https://localhost:5001";

        private readonly HttpClient client;

        public ChildWebServices()
        {
            client = new HttpClient();
        }
        
        public async Task<IList<Child>> GetAllChildrenAsync(int familyId)
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/Children");
            string message = await stringAsync;
            List<Child> result = JsonSerializer.Deserialize<List<Child>>(message);
            return result;
        }

        public async Task<Child> GetChildAsync(int id)
        {
            Task<string> stringAsync = client.GetStringAsync($"{uri}/Children/{id}");
            string message = await stringAsync;
            Child result = JsonSerializer.Deserialize<Child>(message);
            return result;
        }

        public async Task AddChildAsync(Child child)
        {
            string childAsJson = JsonSerializer.Serialize(child);
            HttpContent content = new StringContent(childAsJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage responseMessage = await client.PostAsync($"{uri}/Children", content);

            if (responseMessage.IsSuccessStatusCode)
            {
                Console.WriteLine("Client > Successfully child added.");
            }
        }

        public async Task<Child> RemoveChildAsync(int id)
        {
            HttpResponseMessage responseMessage = await client.DeleteAsync($"{uri}/Children/{id}");
            string reply = await responseMessage.Content.ReadAsStringAsync();

            Child removeChild = JsonSerializer.Deserialize<Child>(reply);

            if (responseMessage.StatusCode == HttpStatusCode.OK)
            {
                return removeChild;
            }

            return null;
        }

        public async Task UpdateChildAsync(Child child)
        {
            string childAsJson = JsonSerializer.Serialize(child);
            HttpContent content = new StringContent(childAsJson,
                Encoding.UTF8,
                "application/json");
            var response = await client.PutAsync($"{uri}/Children", content);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Child >" + response.ReasonPhrase);
            }
            
        }
    }
}