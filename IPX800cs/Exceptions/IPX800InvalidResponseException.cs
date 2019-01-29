using System;

namespace software.elendil.IPX800.Exceptions
{
    public class IPX800InvalidResponseException : IPX800Exception
    {
        public IPX800InvalidResponseException() { }

        public IPX800InvalidResponseException(string message) : base(message) { }

        public IPX800InvalidResponseException(string message, Exception innerException) : base(message, innerException) { }
    }
}