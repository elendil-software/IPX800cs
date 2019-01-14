using System;

namespace software.elendil.IPX800.Exceptions
{
	/// <summary>
	/// Exception that can be thrown by IPX800V2M2M class
	/// </summary>
	public class IPX800Exception : Exception
	{
		/// <summary>
		/// Constructor
		/// </summary>
        public IPX800Exception() { }

        /// <summary>
        /// Constructor
        /// </summary>
		public IPX800Exception(string message) : base(message) { }

        /// <summary>
        /// Constructor
        /// </summary>
		public IPX800Exception(string message, Exception innerException) : base(message, innerException) { }
	}
}
