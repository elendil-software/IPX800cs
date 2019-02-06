using System;

namespace IPX800cs.Exceptions
{
    public class IPX800NotSupportedCommandException : IPX800Exception
    {
        public IPX800NotSupportedCommandException() { }

        public IPX800NotSupportedCommandException(string message) : base(message) { }

        public IPX800NotSupportedCommandException(string message, Exception innerException) : base(message, innerException) { }
    }
}