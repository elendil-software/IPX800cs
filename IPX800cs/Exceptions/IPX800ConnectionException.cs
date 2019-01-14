using System;

namespace software.elendil.IPX800.Exceptions
{
	/// <summary>
	/// Exception that can be thrown by IPX800V3 class
	/// </summary>
	public class IPX800ConnectionException : IPX800Exception
	{
		/// <summary>
		/// Constructor
		/// </summary>
        public IPX800ConnectionException() { }

        /// <summary>
        /// Constructor
        /// </summary>
		public IPX800ConnectionException(string message) : base(message) { }

        /// <summary>
        /// Constructor
        /// </summary>
		public IPX800ConnectionException(string message, Exception innerException) : base(message, innerException) { }
	}
}
