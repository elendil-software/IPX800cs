using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IPX800cs.Parsers.v5;

internal class IOResponse
{
    [Required]
    [JsonPropertyName("_id")]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    public int Link0 { get; set; }
    
    [Required]
    public int Link1 { get; set; }
    
    [Required]
    public bool Virtual { get; set; }
    
    [Required]
    public bool On { get; set; }
}