using Newtonsoft.Json;

namespace IPX800cs.Parsers.v5;

internal class AnaResponse
{
    [JsonProperty("_id")]
    public int Id { get; set; }
    public int Link0 { get; set; }
    public int Link1 { get; set; }
    public string Name { get; set; }
    public string Unit { get; set; }
    public int NbDecimal { get; set; }
    public bool Virtual { get; set; }
    public int Value { get; set; }
}