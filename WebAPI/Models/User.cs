using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("username")]
        public string Username { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [JsonPropertyName("photo")]
        public string Photo { get; set; }
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }
        [JsonPropertyName("lastname")]
        public string LastName { get; set; }
        [JsonPropertyName("securityLevel")]
        public int SecurityLevel { get; set; }
        [JsonPropertyName("role")]
        public string Role { get; set; }
    }
    
}