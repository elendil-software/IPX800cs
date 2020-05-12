using System;
using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetVirtualOutputsHttpResponseParser : IPX800v4HttpParserBase, IGetOutputsResponseParser
    {
        public Dictionary<int, OutputState> ParseResponse(string ipxResponse)
        {
            try
            {
                Dictionary<int, int> inputStates = ParseCollection(ipxResponse, "VO");
                return inputStates.ToDictionary(item => item.Key, item => (OutputState) item.Value);
            }
            catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
            {
                throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response", ex);
            }
        }
    }
}