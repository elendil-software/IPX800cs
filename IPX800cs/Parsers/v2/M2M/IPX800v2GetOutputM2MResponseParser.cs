﻿using IPX800cs.IO;
using IPX800cs.Parsers.v3.Legacy.M2M;

namespace IPX800cs.Parsers.v2.M2M
{
    internal class IPX800v2GetOutputM2MResponseParser : IPX800v2M2MParserBase, IGetOutputResponseParser
    {
        public OutputState ParseResponse(string ipxResponse, int outputNumber)
        {
            ipxResponse.CheckResponse();
            int value = ParseValue(ipxResponse);
            return (OutputState) value;
        }
    }
}