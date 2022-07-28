using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.Http;

internal class IPX800V3GetOutputsHttpResponseParser : IGetOutputsResponseParser
{
    public IEnumerable<OutputResponse> ParseResponse(string ipxResponse)
    {
        Dictionary<int, int> inputStates = JsonParser.ParseCollection(ipxResponse, "OUT");
        return inputStates.Select(pair => new OutputResponse
        {
            Type = OutputType.Output,
            Number = pair.Key,
            Name = $"Output {pair.Key}",
            State = (OutputState)pair.Value
        });
    }
}