using System;

namespace software.elendil.IPX800.ipx800csV1.Exceptions
{
	/// <summary>
	/// IPX800 exception base class
	/// </summary>
	public class IPX800Exception : Exception
	{
        public IPX800Exception() { }

		public IPX800Exception(string message) : base(message) { }

		public IPX800Exception(string message, Exception innerException) : base(message, innerException) { }
	}
}
