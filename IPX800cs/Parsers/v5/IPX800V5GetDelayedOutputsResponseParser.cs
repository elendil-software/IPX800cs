using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v5;

public class IPX800V5GetDelayedOutputsResponseParser : IGetOutputsResponseParser
{
    public IEnumerable<OutputResponse> ParseResponse(string ipxResponse)
    {
        IEnumerable<IOResponse> parsedResponse = ipxResponse.ParseCollectionIO();
        IEnumerable<OutputResponse> outputResponses = parsedResponse.Select(o => new OutputResponseIPX800V5
        {
            Type = OutputType.DelayedOutput,
            State = o.On ? OutputState.Active : OutputState.Inactive,
            Number = o.Id,
            Name = o.Name,
            Link0 = o.Link0,
            Link1 = o.Link1
        });

        return outputResponses;
    }
}