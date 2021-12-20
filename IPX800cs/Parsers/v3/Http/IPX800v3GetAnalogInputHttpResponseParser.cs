using System;
using System.Collections.Generic;
using IPX800cs.Exceptions;

namespace IPX800cs.Parsers.v3.Http;

internal class IPX800v3GetAnalogInputHttpResponseParser : IAnalogInputResponseParser
{
    public int ParseResponse(string ipxResponse, int inputNumber)
    {
        try
        {
            Dictionary<int, int> response = JsonParser.ParseCollection(ipxResponse, "AN");
            return response[inputNumber];
        }
        catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
        {
            throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response", ex);
        }
    }
}