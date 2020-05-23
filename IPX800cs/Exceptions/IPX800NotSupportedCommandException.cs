using System;
using System.Runtime.Serialization;

namespace IPX800cs.Exceptions
{
    [Serializable]
    public class IPX800NotSupportedCommandException : IPX800Exception
    {
        public IPX800NotSupportedCommandException(string message) : base(message) { }

        public IPX800NotSupportedCommandException(string message, Exception innerException) : base(message, innerException) { }
        
        protected IPX800NotSupportedCommandException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}