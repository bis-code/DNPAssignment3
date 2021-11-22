using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using FileData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using WebClient.Data;
using Models;

namespace WebClient.Authentication
{
    public class InMemoryWebService : IUserService
    {
        private readonly DatabaseContext _databaseContext;

        public InMemoryWebService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<User> ValidateUserAsync(string username, string password)
        {
            User first = _databaseContext.Users.FirstOrDefault(user => user.Username.Equals(username));
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