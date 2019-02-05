using System;

namespace software.elendil.IPX800.Exceptions
{
	public class IPX800Exception : Exception
	{
        public IPX800Exception() { }

		public IPX800Exception(string message) : base(message) { }

		public IPX800Exception(string message, Exception innerException) : base(message, innerException) { }
	}
}
