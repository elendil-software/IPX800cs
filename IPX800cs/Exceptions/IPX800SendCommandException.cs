using System;
using System.Runtime.Serialization;

namespace IPX800cs.Exceptions
{
	[Serializable]
	public class IPX800SendCommandException : IPX800Exception
	{
        public IPX800SendCommandException() { }

		public IPX800SendCommandException(string message) : base(message) { }

		public IPX800SendCommandException(string message, Exception innerException) : base(message, innerException) { }
		
		protected IPX800SendCommandException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
