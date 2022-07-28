using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.Http;

internal class IPX800V4GetVirtualOutputsHttpResponseParser : IGetOutputsResponseParser
{
    public IEnumerable<OutputResponse> ParseResponse(string ipxResponse)
    {
        Dictionary<int, int> inputStates = JsonParser.ParseCollection(ipxResponse, "VO");
        return inputStates.Select(pair => new OutputResponse
        {
            Type = OutputType.VirtualOutput,
            Number = pair.Key,
            Name = $"Virtual Output {pair.Key}",
            State = (OutputState)pair.Value
        });
    }
}