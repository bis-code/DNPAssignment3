using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models {
    [Table("Children")]
public class Child : Person {
    
    [JsonPropertyName("Interests")]
    public ICollection<Interest> Interests { get; set; }
    [JsonPropertyName("Pets")]
    public ICollection<Pet> Pets { get; set; }
}
}