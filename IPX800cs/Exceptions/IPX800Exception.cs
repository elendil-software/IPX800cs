using System;

namespace software.elendil.IPX800.Exceptions
{
	public class IPX800Exception : Exception
	{
		protected IPX800Exception() { }

		protected IPX800Exception(string message) : base(message) { }

		protected IPX800Exception(string message, Exception innerException) : base(message, innerException) { }
	}
}
