using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic.CompilerServices;

namespace Models {
public class Person {
    
    [JsonPropertyName("Id")]
    public int Id { get; set; }
    [JsonPropertyName("FirstName")]
    public string FirstName { get; set; }
    [JsonPropertyName("LastName")]
    public string LastName { get; set; }
    [JsonPropertyName("HairColor")]
    public string HairColor { get; set; }
    [JsonPropertyName("EyeColor")]
    public string EyeColor { get; set; }
    [JsonPropertyName("Age")]
    public int Age { get; set; }
    [JsonPropertyName("Weight")]
    public float Weight { get; set; }
    [JsonPropertyName("Height")]
    public int Height { get; set; }
    [JsonPropertyName("Sex")]
    public string Sex { get; set; }
    [JsonPropertyName("Photo")]
    public string Photo { get; set; }
}


}