﻿using IPX800cs.IO;

namespace IPX800cs.Parsers.v5;

internal class IPX800V5GetOutputResponseParser : IGetOutputResponseParser
{
    public OutputState ParseResponse(string ipxResponse, int outputNumber)
    {
        IOResponse response = ipxResponse.ParseIO();
        return response.On ? OutputState.Active : OutputState.Inactive;
    }
}