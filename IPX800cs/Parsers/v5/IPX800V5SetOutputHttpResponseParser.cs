﻿namespace IPX800cs.Parsers.v5;

internal class IPX800V5SetOutputResponseParser : ISetOutputResponseParser
{
    public bool ParseResponse(string ipxResponse)
    {
        IOResponse response = ipxResponse.ParseIO();
        return response.Id != 0;
    }
}