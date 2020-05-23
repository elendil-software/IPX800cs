using System;
using System.Runtime.Serialization;

namespace IPX800cs.Exceptions
{
	[Serializable]
	public class IPX800InvalidContextException : IPX800Exception
	{
        public IPX800InvalidContextException(string message) : base(message) { }

		public IPX800InvalidContextException(string message, Exception innerException) : base(message, innerException) { }
		
		protected IPX800InvalidContextException(SerializationInfo info, StreamingContext context) : base(info, context) { }
	}
}
