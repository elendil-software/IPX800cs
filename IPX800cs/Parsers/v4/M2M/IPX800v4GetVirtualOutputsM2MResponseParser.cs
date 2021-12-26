using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.M2M;

internal class IPX800v4GetVirtualOutputsM2MResponseParser : ResponseParserBase, IGetOutputsResponseParser
{
    public IEnumerable<OutputResponse> ParseResponse(string ipxResponse)
    {
        ipxResponse = ipxResponse?.Replace("VO=", "");
        Dictionary<int, int> outputStates = ParseCollection(ipxResponse, "VO");
        return outputStates.Select(pair => new OutputResponse
        {
            Type = OutputType.VirtualOutput,
            Number = pair.Key,
            Name = $"Virtual Output {pair.Key}",
            State = (OutputState)pair.Value
        });
    }
}