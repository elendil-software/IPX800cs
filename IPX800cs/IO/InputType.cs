namespace IPX800cs.IO;

/// <summary>
/// Represent the input types of an IPX800.
///
/// Some option are not supported by all IPX800 device versions
/// </summary>
public enum InputType
{
    /// <summary>
    /// Digital input
    /// Supported by IPX800 v2, v3, v4, v5
    /// </summary>
    DigitalInput,
    
    /// <summary>
    /// Digital input
    /// Supported by IPX800 v4, v5
    /// </summary>
    VirtualDigitalInput,
    
    /// <summary>
    /// Digital input
    /// Supported by IPX800 v5
    /// </summary>
    OptoInput
}