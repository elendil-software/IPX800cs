using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace IPX800cs.Parsers.v5;

internal class AnaResponse
{
    [Required]
    [JsonPropertyName("_id")]
    public int Id { get; set; }
    [Required]
    public int Link0 { get; set; }
    [Required]
    public int Link1 { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Unit { get; set; }
    [Required]
    public int NbDecimal { get; set; }
    [Required]
    public bool Virtual { get; set; }
    [Required]
    public double Value { get; set; }
}