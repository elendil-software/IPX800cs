using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v5;

public class IPX800V5GetOutputsResponseParser : IGetOutputsResponseParser
{
    protected int MinId;
    protected int MaxId;
    protected OutputType OutputType;

    public IPX800V5GetOutputsResponseParser()
    {
        MinId = 65536;
        MaxId = 65543;
        OutputType = OutputType.Output;
    }
    
    public IEnumerable<OutputResponse> ParseResponse(string ipxResponse)
    {
        IEnumerable<IOResponse> parsedResponse = ipxResponse.ParseCollectionIO();
        IEnumerable<OutputResponse> outputResponses = parsedResponse.Where(o => o.Id >= MinId && o.Id <= MaxId).Select(o => new OutputResponse
        {
            Type = OutputType,
            State = o.On ? OutputState.Active : OutputState.Inactive,
            Number = o.Id,
            Name = o.Name
        });

        return outputResponses;
    }
}