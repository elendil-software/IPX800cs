using System;
using System.Runtime.Serialization;

namespace IPX800cs.Exceptions;

/// <summary>
/// Represents errors that occur when a command is not supported by the device (e.g. IPX800 v3 does not support virtual inputs)
/// </summary>
[Serializable]
public class IPX800NotSupportedCommandException : IPX800Exception
{
    /// <summary>
    /// Initializes a new instance of the IPX800NotSupportedCommandException class with a specified error message.
    /// </summary>
    public IPX800NotSupportedCommandException(string message) : base(message) { }

    /// <summary>
    /// Initializes a new instance of the IPX800NotSupportedCommandException class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    public IPX800NotSupportedCommandException(string message, Exception innerException) : base(message, innerException) { }
    
    /// <summary>
    /// Initializes a new instance of the IPX800NotSupportedCommandException class with serialized data.
    /// </summary>
    protected IPX800NotSupportedCommandException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}