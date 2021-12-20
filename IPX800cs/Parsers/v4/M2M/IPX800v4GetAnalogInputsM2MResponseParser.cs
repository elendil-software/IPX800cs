using System.Collections.Generic;

namespace IPX800cs.Parsers.v4.M2M;

internal class IPX800v4GetAnalogInputsM2MResponseParser : ResponseParserBase, IAnalogInputsResponseParser
{
    public Dictionary<int, int> ParseResponse(string ipxResponse)
    {
        return ParseCollection(ipxResponse, "A");
    }
}