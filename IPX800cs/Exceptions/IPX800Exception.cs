using System;
using System.Runtime.Serialization;

namespace IPX800cs.Exceptions;

[Serializable]
public class IPX800Exception : Exception
{
	protected IPX800Exception(string message) : base(message) { }

	protected IPX800Exception(string message, Exception innerException) : base(message, innerException) { }
		
	protected IPX800Exception(SerializationInfo info, StreamingContext context) : base(info, context) { }
}