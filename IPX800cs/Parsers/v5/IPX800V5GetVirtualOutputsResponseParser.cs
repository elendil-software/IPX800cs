using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v5;

internal class IPX800V5GetVirtualOutputsResponseParser : IGetOutputsResponseParser
{
    protected OutputType OutputType;
    
    public IEnumerable<OutputResponse> ParseResponse(string ipxResponse)
    {
        IEnumerable<IOResponse> parsedResponse = ipxResponse.ParseCollectionIO();
        IEnumerable<OutputResponse> outputResponses = parsedResponse
                .Where(o => o.Virtual)
                .Select(o => new OutputResponseIPX800V5
        {
            Type = OutputType.VirtualOutput,
            State = o.On ? OutputState.Active : OutputState.Inactive,
            Number = o.Id,
            Name = o.Name,
            Link0 = o.Link0,
            Link1 = o.Link1
        });

        return outputResponses;
    }
}