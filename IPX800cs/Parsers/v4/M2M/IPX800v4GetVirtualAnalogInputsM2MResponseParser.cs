using System.Collections.Generic;

namespace IPX800cs.Parsers.v4.M2M
{
    internal class IPX800v4GetVirtualAnalogInputsM2MResponseParser : AnalogInputsResponseParserBase, IAnalogInputsResponseParser
    {
        public Dictionary<int, int> ParseResponse(string ipxResponse)
        {
            int prefixLength = 2;
            return ParseResponse(ipxResponse, prefixLength);
        }
    }
}