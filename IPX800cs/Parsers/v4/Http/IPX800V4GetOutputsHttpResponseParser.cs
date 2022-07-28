using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.Http;

internal class IPX800V4GetOutputsHttpResponseParser : IGetOutputsResponseParser
{
    public IEnumerable<OutputResponse> ParseResponse(string ipxResponse)
    {
        Dictionary<int, int> outputStates = JsonParser.ParseCollection(ipxResponse, "R");
        return outputStates.Select(pair => new OutputResponse
        {
            Type = OutputType.Output,
            Number = pair.Key,
            Name = $"Output {pair.Key}",
            State = (OutputState)pair.Value
        });
    }
}