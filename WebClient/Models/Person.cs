using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace Models
{
    [Table("Persons")]
    public class Person
    {
        [JsonPropertyName("FamilyId")]
        [ForeignKey("FamilyId")]
        public int FamilyId { get; set; }

        [JsonPropertyName("Id")] [Key] public int Id { get; set; }

        [JsonPropertyName("FirstName")]
        [Required, MaxLength(256)]
        public string FirstName { get; set; }

        [Required, MaxLength(256)]
        [JsonPropertyName("LastName")]
        public string LastName { get; set; }

        [Required, MaxLength(128)]
        [JsonPropertyName("HairColor")]
        public string HairColor { get; set; }

        [JsonPropertyName("EyeColor")]
        [Required, MaxLength(128)]
        public string EyeColor { get; set; }

        [JsonPropertyName("Age")]
        [Required, Range(1, 100, ErrorMessage = "Insert age again (Max 100)")]
        public int Age { get; set; }

        [JsonPropertyName("Weight")]
        [Required]
        public float Weight { get; set; }

        [Required]
        [JsonPropertyName("Height")]
        public int Height { get; set; }

        [JsonPropertyName("Sex")]
        [Required, MaxLength(1, ErrorMessage = "'M' or 'F' required")]
        public string Sex { get; set; }

        [JsonPropertyName("Photo")]
        [MaxLength(256)]
        public string Photo { get; set; }
    }
}