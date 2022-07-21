using System;
using System.Runtime.Serialization;

namespace IPX800cs.Exceptions;

/// <summary>
/// Represents errors that occur when a command has been successfully sent but the response can not be parsed
/// </summary>
[Serializable]
public class IPX800InvalidResponseException : IPX800Exception
{
    /// <summary>
    /// Initializes a new instance of the IPX800InvalidResponseException class with a specified error message.
    /// </summary>
    public IPX800InvalidResponseException(string ipxResponse) : base($"'{ipxResponse}' is not a valid response") { }

    /// <summary>
    /// Initializes a new instance of the IPX800InvalidResponseException class with a specified error message and a reference to the inner exception that is the cause of this exception.
    /// </summary>
    public IPX800InvalidResponseException(string ipxResponse, Exception innerException) : base($"'{ipxResponse}' is not a valid response", innerException) { }
    
    /// <summary>
    /// Initializes a new instance of the IPX800InvalidResponseException class with serialized data.
    /// </summary>
    protected IPX800InvalidResponseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}