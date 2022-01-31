using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v5;

internal class IPX800V5GetAnalogInputsResponseParser : IAnalogInputsResponseParser
{
    public IEnumerable<AnalogInputResponse> ParseResponse(string ipxResponse)
    {
        IEnumerable<AnaResponse> parsedResponse = ipxResponse.ParseCollectionAna();
        IEnumerable<AnalogInputResponse> outputResponses = parsedResponse.Where(i => i.Id is >= 262144 and <= 262147).Select(i => new AnalogInputResponse
        {
            Type = AnalogInputType.AnalogInput,
            Number = i.Id,
            Name = i.Name,
            Value = i.Value
        });

        return outputResponses;
    }
}