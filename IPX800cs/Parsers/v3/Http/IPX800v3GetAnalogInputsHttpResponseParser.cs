using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.Http;

internal class IPX800v3GetAnalogInputsHttpResponseParser : IAnalogInputsResponseParser
{
    public IEnumerable<AnalogInputResponse> ParseResponse(string ipxResponse)
    {
        Dictionary<int, int> inputStates = JsonParser.ParseCollection(ipxResponse, "AN");
        return inputStates.Select(pair => new AnalogInputResponse
        {
            Type = AnalogInputType.AnalogInput,
            Number = pair.Key,
            Name = $"Analog {pair.Key}",
            Value = pair.Value
        });
    }
}