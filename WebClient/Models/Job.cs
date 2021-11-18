using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Models
{
    public class Job
    {
        [JsonPropertyName("JobTitle")]
        public string JobTitle { get; set; }
        [JsonPropertyName("Salary")]
        public int Salary { get; set; }
    }
}