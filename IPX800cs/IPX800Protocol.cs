namespace IPX800cs;

/// <summary>
/// Protocols supported by the IPX800 devices.
///
/// Note : IPX800 v5 support only Http
/// </summary>
public enum IPX800Protocol
{
    /// <summary>
    /// Machine to Machine
    /// </summary>
    M2M, 
    
    /// <summary>
    /// Http
    /// </summary>
    Http
}