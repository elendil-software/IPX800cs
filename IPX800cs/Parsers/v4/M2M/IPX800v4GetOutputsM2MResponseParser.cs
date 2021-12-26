using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.M2M;

internal class IPX800v4GetOutputsM2MResponseParser : ResponseParserBase, IGetOutputsResponseParser
{
    public IEnumerable<OutputResponse> ParseResponse(string ipxResponse)
    {
        Dictionary<int, int> outputStates = ParseCollection(ipxResponse, "R");
        return outputStates.Select(pair => new OutputResponse
        {
            Type = OutputType.Output,
            Number = pair.Key,
            Name = $"Output {pair.Key}",
            State = (OutputState)pair.Value
        });
    }
}