using System;

namespace software.elendil.IPX800.Exceptions
{
	/// <summary>
	/// Exception that can be thrown when something wrong occurs while sending a command to an IPX800
	/// </summary>
	public class IPX800SendCommandException : IPX800Exception
	{
        public IPX800SendCommandException() { }

		public IPX800SendCommandException(string message) : base(message) { }

		public IPX800SendCommandException(string message, Exception innerException) : base(message, innerException) { }
	}
}
