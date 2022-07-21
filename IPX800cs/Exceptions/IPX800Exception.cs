using System;
using System.Runtime.Serialization;

namespace IPX800cs.Exceptions;

/// <summary>
/// Represents errors that occur during IPX800cs library usage.
/// </summary>
[Serializable]
public class IPX800Exception : Exception
{
	/// <summary>
	/// Initializes a new instance of the IPX800Exception class with a specified error message.
	/// </summary>
	protected IPX800Exception(string message) : base(message) { }

	/// <summary>
	/// Initializes a new instance of the IPX800Exception class with a specified error message and a reference to the inner exception that is the cause of this exception.
	/// </summary>
	protected IPX800Exception(string message, Exception innerException) : base(message, innerException) { }
		
	/// <summary>
	/// Initializes a new instance of the Exception class with serialized data.
	/// </summary>
	protected IPX800Exception(SerializationInfo info, StreamingContext context) : base(info, context) { }
}