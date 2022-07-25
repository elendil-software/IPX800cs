using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#pragma warning disable CS1591

namespace IPX800cs.Parsers.v5;

public class TimerResponse
{
    [Required]
    [JsonPropertyName("_id")]
    public int Id { get; set; }

    [Required] 
    public string Name { get; set; }

    public string ErrorStatus { get; set; }

    [Required] 
    public string Func { get; set; }

    [JsonPropertyName("bSecond")]
    public bool Second { get; set; }

    [JsonPropertyName("bOnOff")]
    public bool OnOff { get; set; }

    [JsonPropertyName("bSingle")]
    public bool Single { get; set; }

    [JsonPropertyName("ioStart_id")]
    public int IoStartId { get; set; }

    [JsonPropertyName("ioEnable_id")]
    public int IoEnableId { get; set; }

    [JsonPropertyName("anaCounter1_id")]
    public int Counter1Id { get; set; }

    [JsonPropertyName("anaTime1_id")]
    public int Time1Id { get; set; }

    [JsonPropertyName("ioOut_id")]
    public int IoOutId { get; set; }
}