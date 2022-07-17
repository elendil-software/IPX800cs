namespace IPX800cs.IO;

/// <summary>
/// Represent an output. It is use to send command to an IPX800
/// </summary>
public class Output
{
    /// <summary>
    /// output type
    /// </summary>
    public OutputType Type { get; set; }
    
    /// <summary>
    /// The state to set to the output
    /// It will be ignored in case of delayed output or in get request
    /// </summary>
    public OutputState State { get; set; }
    
    /// <summary>
    /// Number of the output
    /// </summary>
    public int Number { get; set; }
}