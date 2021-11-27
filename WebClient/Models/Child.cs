using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Children")]
    public class Child : Person
    {
        [JsonPropertyName("Interests")] public List<Interest> Interests { get; set; }
        [JsonPropertyName("Pets")] public List<Pet> Pets { get; set; }
    }
}