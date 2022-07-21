using Newtonsoft.Json;
#pragma warning disable CS1591

namespace IPX800cs.Parsers.v5;

public class TimerResponse
{
    [JsonRequired]
    [JsonProperty("_id")]
    public int Id { get; set; }

    [JsonRequired] 
    public string Name { get; set; }

    public string ErrorStatus { get; set; }

    [JsonRequired] 
    public string Func { get; set; }

    [JsonProperty("bSecond")]
    public bool Second { get; set; }

    [JsonProperty("bOnOff")]
    public bool OnOff { get; set; }

    [JsonProperty("bSingle")]
    public bool Single { get; set; }

    [JsonProperty("ioStart_id")]
    public int IoStartId { get; set; }

    [JsonProperty("ioEnable_id")]
    public int IoEnableId { get; set; }

    [JsonProperty("anaCounter1_id")]
    public int Counter1Id { get; set; }

    [JsonProperty("anaTime1_id")]
    public int Time1Id { get; set; }

    [JsonProperty("ioOut_id")]
    public int IoOutId { get; set; }
}