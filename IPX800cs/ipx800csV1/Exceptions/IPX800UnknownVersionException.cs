using System;

namespace software.elendil.IPX800.ipx800csV1.Exceptions
{
	/// <summary>
	/// Exception that can be thrown when the firmware version can not be identified
	/// </summary>
	public class IPX800UnknownVersionException : IPX800Exception
	{
        public IPX800UnknownVersionException() { }

		public IPX800UnknownVersionException(string message) : base(message) { }

		public IPX800UnknownVersionException(string message, Exception innerException) : base(message, innerException) { }
	}
}
