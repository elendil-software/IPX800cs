﻿namespace IPX800cs.Parsers.v2.M2M;

internal class IPX800V2GetGetAnalogInputM2MResponseParser : IPX800v2M2MParserBase, IGetAnalogInputResponseParser
{
    public int ParseResponse(string ipxResponse, int inputNumber)
    {
        ipxResponse.CheckResponse();
        return ParseValue(ipxResponse);
    }
}