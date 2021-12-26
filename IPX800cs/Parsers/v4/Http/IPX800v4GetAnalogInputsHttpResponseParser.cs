using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.Http;

internal class IPX800v4GetAnalogInputsHttpResponseParser : IAnalogInputsResponseParser
{
    public IEnumerable<AnalogInputResponse> ParseResponse(string ipxResponse)
    {
        return JsonParser.ParseCollection(ipxResponse, "A")
                        .Select(pair => new AnalogInputResponse
                        {
                            Type = AnalogInputType.AnalogInput,
                            Number = pair.Key,
                            Name = $"Analog {pair.Key}",
                            Value = pair.Value
                        });
    }
}