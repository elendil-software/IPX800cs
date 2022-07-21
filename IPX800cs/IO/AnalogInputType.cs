namespace IPX800cs.IO;

/// <summary>
/// Represent the analog input types of an IPX800.
///
/// Some option are not supported by all IPX800 device versions
/// </summary>
public enum AnalogInputType
{
    /// <summary>
    /// Analog input
    /// Supported by IPX800 v2, v3, v4, v5
    /// </summary>
    AnalogInput,
    
    /// <summary>
    /// Analog input
    /// Supported by IPX800 v4
    /// </summary>
    VirtualAnalogInput
}