namespace IPX800cs.IO;

/// <summary>
/// Represent an input response. It is use to return the response of a request set to an IPX800
/// </summary>
public class InputResponse : Input
{
    /// <summary>
    /// Name of the input
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Current input state
    /// </summary>
    public InputState State { get; set; }
}