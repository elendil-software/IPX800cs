using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.Http;

internal class IPX800v4GetVirtualOutputsHttpResponseParser : IGetOutputsResponseParser
{
    public Dictionary<int, OutputState> ParseResponse(string ipxResponse)
    {
        Dictionary<int, int> inputStates = JsonParser.ParseCollection(ipxResponse, "VO");
        return inputStates.ToDictionary(item => item.Key, item => (OutputState) item.Value);
    }
}