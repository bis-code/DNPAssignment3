using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models {
    [Table("Pets")]
public class Pet {
    [JsonPropertyName("Id")]
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(128)]
    [JsonPropertyName("Species")]
    public string Species { get; set; }
    [Required, MaxLength(128)]
    [JsonPropertyName("Name")]
    public string Name { get; set; }
    [JsonPropertyName("Age")]
    [Required, Range(1,30, ErrorMessage = "Age too big (max 30)")]
    public int Age { get; set; }
}
}