namespace IPX800cs.IO;

/// <summary>
/// Represent an analog input response. It is use to return the response of a request set to an IPX800
/// </summary>
public class AnalogInputResponse : AnalogInput
{
    /// <summary>
    /// Name of the input
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Current value of the analog input
    /// </summary>
    public double Value { get; set; }
}