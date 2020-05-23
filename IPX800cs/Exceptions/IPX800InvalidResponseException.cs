using System;
using System.Runtime.Serialization;

namespace IPX800cs.Exceptions
{
    [Serializable]
    public class IPX800InvalidResponseException : IPX800Exception
    {
        public IPX800InvalidResponseException(string ipxResponse) : base($"'{ipxResponse}' is not a valid response") { }

        public IPX800InvalidResponseException(string ipxResponse, Exception innerException) : base($"'{ipxResponse}' is not a valid response", innerException) { }
		
        protected IPX800InvalidResponseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}