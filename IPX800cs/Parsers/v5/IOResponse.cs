using Newtonsoft.Json;

namespace IPX800cs.Parsers.v5;

internal class IOResponse
{
    [JsonRequiredAttribute]
    [JsonProperty("_id")]
    public int Id { get; set; }
    
    [JsonRequiredAttribute]
    public string Name { get; set; }
    
    [JsonRequiredAttribute]
    public int Link0 { get; set; }
    
    [JsonRequiredAttribute]
    public int Link1 { get; set; }
    
    [JsonRequiredAttribute]
    public bool Virtual { get; set; }
    
    [JsonRequiredAttribute]
    public bool On { get; set; }
}