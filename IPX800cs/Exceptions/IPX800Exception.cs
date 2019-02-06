using System;

namespace IPX800cs.Exceptions
{
	public class IPX800Exception : Exception
	{
		protected IPX800Exception() { }

		protected IPX800Exception(string message) : base(message) { }

		protected IPX800Exception(string message, Exception innerException) : base(message, innerException) { }
	}
}
