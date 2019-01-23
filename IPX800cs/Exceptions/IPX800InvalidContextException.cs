using System;

namespace software.elendil.IPX800.Exceptions
{
	public class IPX800InvalidContextException : IPX800Exception
	{
        public IPX800InvalidContextException() { }

		public IPX800InvalidContextException(string message) : base(message) { }

		public IPX800InvalidContextException(string message, Exception innerException) : base(message, innerException) { }
	}
}
