using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.Http
{
    internal class IPX800v3GetOutputHttpResponseParser : IGetOutputResponseParser
    {
        public OutputState ParseResponse(string ipxResponse, int outputNumber)
        {
            Dictionary<int, OutputState> response = new IPX800v3GetOutputsHttpResponseParser().ParseResponse(ipxResponse);
            return response[outputNumber];
        }
    }
}