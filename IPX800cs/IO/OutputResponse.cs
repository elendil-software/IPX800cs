namespace IPX800cs.IO;

/// <summary>
/// Represent an output response. It is use to return the response of a request set to an IPX800
/// </summary>
public class OutputResponse : Output
{
    /// <summary>
    /// Name of the output
    /// </summary>
    public string Name { get; set; }
}