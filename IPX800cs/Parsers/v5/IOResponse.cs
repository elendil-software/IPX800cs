using Newtonsoft.Json;

namespace IPX800cs.Parsers.v5;

internal class IOResponse
{
    [JsonProperty("_id")]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Link0 { get; set; }
    public int Link1 { get; set; }
    public bool Virtual { get; set; }
    public bool On { get; set; }
}