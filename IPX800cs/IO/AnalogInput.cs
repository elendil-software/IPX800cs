namespace IPX800cs.IO;

/// <summary>
/// Represent an analog input. It is use to send command to an IPX800
/// </summary>
public class AnalogInput
{
    /// <summary>
    /// Analog input type
    /// </summary>
    public AnalogInputType Type { get; set; }
    
    /// <summary>
    /// Number of the analog input
    /// </summary>
    public int Number { get; set; }
}