using System;
using System.Runtime.Serialization;

namespace IPX800cs.Exceptions;

/// <summary>
/// Represents errors that occur during the initialisation of an instance of an <see cref="IIPX800"/> implementation  when a parameter is not supported
/// </summary>
[Serializable]
public class IPX800InvalidContextException : IPX800Exception
{
	/// <summary>
	/// Initializes a new instance of the IPX800InvalidContextException class with a specified error message.
	/// </summary>
	public IPX800InvalidContextException(string message) : base(message) { }

	/// <summary>
	/// Initializes a new instance of the IPX800InvalidContextException class with a specified error message and a reference to the inner exception that is the cause of this exception.
	/// </summary>
	public IPX800InvalidContextException(string message, Exception innerException) : base(message, innerException) { }
	
	/// <summary>
	/// Initializes a new instance of the IPX800InvalidContextException class with serialized data.
	/// </summary>
	protected IPX800InvalidContextException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}