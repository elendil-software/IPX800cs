namespace IPX800cs.IO;

/// <summary>
/// Represent an input. It is use to send command to an IPX800
/// </summary>
public class Input
{
    /// <summary>
    /// Input type
    /// </summary>
    public InputType Type { get; set; }
    
    /// <summary>
    /// Number of the input
    /// </summary>
    public int Number { get; set; }
}