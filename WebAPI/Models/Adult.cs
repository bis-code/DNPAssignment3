using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Adults")]
    public class Adult : Person
    {
        [JsonPropertyName("JobTitle")]
        [Required, MaxLength(50)]
        public string JobTitle { get; set; }
        [JsonPropertyName("Salary")]
        [Required, Range(10000,1000000, ErrorMessage = "You cannot add a salary less then 10.000 krones")]
        public int Salary { get; set; }
    }
}