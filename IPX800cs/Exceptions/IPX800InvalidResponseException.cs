using System;
using System.Runtime.Serialization;

namespace IPX800cs.Exceptions
{
    [Serializable]
    public class IPX800InvalidResponseException : IPX800Exception
    {
        public IPX800InvalidResponseException() { }

        public IPX800InvalidResponseException(string message) : base(message) { }

        public IPX800InvalidResponseException(string message, Exception innerException) : base(message, innerException) { }
		
        protected IPX800InvalidResponseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}