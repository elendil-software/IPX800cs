using System;

namespace IPX800cs.Exceptions
{
	public class IPX800UnknownVersionException : IPX800Exception
	{
        public IPX800UnknownVersionException() { }

		public IPX800UnknownVersionException(string message) : base(message) { }

		public IPX800UnknownVersionException(string message, Exception innerException) : base(message, innerException) { }
	}
}
