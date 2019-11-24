using System;
using System.Runtime.Serialization;

namespace IPX800cs.Exceptions
{
	[Serializable]
	public class IPX800UnknownVersionException : IPX800Exception
	{
        public IPX800UnknownVersionException() { }

		public IPX800UnknownVersionException(string message) : base(message) { }

		public IPX800UnknownVersionException(string message, Exception innerException) : base(message, innerException) { }
		
		protected IPX800UnknownVersionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
