using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.Http;

internal class IPX800v4GetVirtualAnalogInputsHttpResponseParser : IAnalogInputsResponseParser
{
    public IEnumerable<AnalogInputResponse> ParseResponse(string ipxResponse)
    {
        return JsonParser.ParseCollection(ipxResponse, "VA").Select(pair => new AnalogInputResponse
        {
            Type = AnalogInputType.VirtualAnalogInput,
            Number = pair.Key,
            Name = $"Virtual Analog {pair.Key}",
            Value = pair.Value
        });
    }
}