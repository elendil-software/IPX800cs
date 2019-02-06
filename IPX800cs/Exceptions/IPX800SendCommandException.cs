using System;

namespace IPX800cs.Exceptions
{
	public class IPX800SendCommandException : IPX800Exception
	{
        public IPX800SendCommandException() { }

		public IPX800SendCommandException(string message) : base(message) { }

		public IPX800SendCommandException(string message, Exception innerException) : base(message, innerException) { }
	}
}
