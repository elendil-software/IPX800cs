namespace IPX800cs.IO;

/// <summary>
/// Represent an IPX800 V5 output response. It is use to return the response of a request set to an IPX800 V5
/// </summary>
public class OutputResponseIPX800V5 : OutputResponse
{
    /// <summary>
    /// Link0 property value.
    /// It contains the number of an other I/O linked as an input to the current output
    /// </summary>
    public int Link0 { get; set; }
    
    /// <summary>
    /// Link1 property value.
    /// It contains the number of an other I/O linked as an output the current output
    /// </summary>
    public int Link1 { get; set; }
}