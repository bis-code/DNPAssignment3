using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Users")]
    public class User
    {
        [JsonPropertyName("id")]
        [Key]
        public int Id { get; set; }
        [JsonPropertyName("username")]
        [Required, MaxLength(128)]
        public string Username { get; set; }
        [Required, MaxLength(128)]
        [JsonPropertyName("password")]
        public string Password { get; set; }
        [Required, MaxLength(128)]
        [JsonPropertyName("photo")]
        public string Photo { get; set; }
        [MaxLength(128)]
        [JsonPropertyName("firstname")]
        public string FirstName { get; set; }
        [MaxLength(128)]
        [JsonPropertyName("lastname")]
        public string LastName { get; set; }
        [JsonPropertyName("securityLevel")]
        [MaxLength, Range(1,5, ErrorMessage = "Security Level cannot be more than 5")]
        public int SecurityLevel { get; set; }
        [JsonPropertyName("role")]
        [Required, MaxLength(128)]
        public string Role { get; set; }
    }
    
}