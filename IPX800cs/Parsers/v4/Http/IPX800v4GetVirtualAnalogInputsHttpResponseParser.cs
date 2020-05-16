using System;
using System.Collections.Generic;
using IPX800cs.Exceptions;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetVirtualAnalogInputsHttpResponseParser : IAnalogInputsResponseParser
    {
        public Dictionary<int, int> ParseResponse(string ipxResponse)
        {
            try
            {
                return JsonParser.ParseCollection(ipxResponse, "VA");
            }
            catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
            {
                throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response", ex);
            }
        }
    }
}