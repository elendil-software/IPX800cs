using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.M2M;

internal class IPX800V4GetAnalogInputsM2MResponseParser : ResponseParserBase, IAnalogInputsResponseParser
{
    public IEnumerable<AnalogInputResponse> ParseResponse(string ipxResponse)
    {
        return ParseCollection(ipxResponse, "A").Select(pair => new AnalogInputResponse
        {
            Type = AnalogInputType.AnalogInput,
            Number = pair.Key,
            Name = $"Analog {pair.Key}",
            Value = pair.Value
        });
    }
}