﻿using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.Http;

internal class IPX800V4GetOutputHttpResponseParser : IGetOutputResponseParser
{
    public OutputState ParseResponse(string ipxResponse, int outputNumber)
    {
        return (OutputState) JsonParser.ParseValue(ipxResponse, $"R{outputNumber}"); 
    }
}