namespace IPX800cs.IO;

/// <summary>
/// Represent the output types of an IPX800.
///
/// Some option are not supported by all IPX800 device versions
/// </summary>
public enum OutputType
{
    /// <summary>
    /// Output
    /// Supported by IPX800 v2, v3, v4, v5
    /// </summary>
    Output,
    
    /// <summary>
    /// Virtual Output
    /// Supported by IPX800 v4, v5
    /// </summary>
    VirtualOutput,
    
    /// <summary>
    /// Delayed Output
    /// Supported by IPX800 v2, v3, v4, v5
    /// </summary>
    DelayedOutput,
    
    /// <summary>
    /// Delayed Virtual Output
    /// Supported by IPX800 v4, v5
    /// </summary>
    DelayedVirtualOutput,
    
    /// <summary>
    /// Open-Collector Output
    /// Supported by IPX800 v5
    /// </summary>
    OpenCollectorOutput,
    
    /// <summary>
    /// Delayed Open-Collector Output
    /// Supported by IPX800 v5
    /// </summary>
    DelayedOpenCollectorOutput
}