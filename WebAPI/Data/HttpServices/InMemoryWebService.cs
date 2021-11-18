using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebClient.Data;
using Models;

namespace WebClient.Authentication
{
    public class InMemoryWebService : IUserService
    {
        private IList<User> users;

        public InMemoryWebService()
        {
            users = new[]
            {
                new User()
                {
                    Username = "Ionut",
                    Id = 2,
                    Password = "12345",
                    SecurityLevel = 4,
                    Role = "Admin",
                },
                new User()
                {
                    Username = "Baicoianu",
                    Id = 3,
                    Password = "12345",
                    SecurityLevel = 2,
                    Role = "Member",
                }
            }.ToList();
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            User first = users.FirstOrDefault(user => user.Username.Equals(username));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            return first;
        }
    }
}