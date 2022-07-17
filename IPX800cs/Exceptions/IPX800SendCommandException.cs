using System;
using System.Runtime.Serialization;

namespace IPX800cs.Exceptions;

/// <summary>
/// Represents errors that occur while sending the command or it was not possible to send the command
/// </summary>
[Serializable]
public class IPX800SendCommandException : IPX800Exception
{
	/// <summary>
	/// Initializes a new instance of the IPX800SendCommandException class with a specified error message.
	/// </summary>
	public IPX800SendCommandException(string message) : base(message) { }

	/// <summary>
	/// Initializes a new instance of the IPX800SendCommandException class with a specified error message and a reference to the inner exception that is the cause of this exception.
	/// </summary>
	public IPX800SendCommandException(string message, Exception innerException) : base(message, innerException) { }
	
	/// <summary>
	/// Initializes a new instance of the IPX800SendCommandException class with serialized data.
	/// </summary>
	protected IPX800SendCommandException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}