using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Models
{
    [Table("Adults")]
    public class Adult : Person
    {
        [JsonPropertyName("JobTitle")]
        public Job JobTitle { get; set; }

        public Adult()
        {
            JobTitle = new Job();
        }
    }
}