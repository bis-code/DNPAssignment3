using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Data;
using Models;

namespace WebClient.Data.HttpServices
{
    public class InMemoryWebService : IUserService
    {
        private readonly HttpClient client;
        public InMemoryWebService()
        {
            client = new HttpClient();
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            
            HttpResponseMessage response = await client.GetAsync($"https://localhost:5001/users?username={username}&password={password}");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                string userAsJson = await response.Content.ReadAsStringAsync();
                User resultUser = JsonSerializer.Deserialize<User>(userAsJson);
                return resultUser;
            } 
            throw new Exception("User not found");
        }
    }
}