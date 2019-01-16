using System;

namespace software.elendil.IPX800.Exceptions
{
	/// <summary>
	/// Exception that can be thrown when something wrong occurs while sending a command to an IPX800
	/// </summary>
	public class IPX800CommandException : IPX800Exception
	{
        public IPX800CommandException() { }

		public IPX800CommandException(string message) : base(message) { }

		public IPX800CommandException(string message, Exception innerException) : base(message, innerException) { }
	}
}
