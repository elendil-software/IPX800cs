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
        OutputType = OutputType.Output;
        MinId = IPX800V5Const.IOIds[OutputType][0];
        MaxId =  IPX800V5Const.IOIds[OutputType][1];
        
    }
    
    public IEnumerable<OutputResponse> ParseResponse(string ipxResponse)
    {
        IEnumerable<IOResponse> parsedResponse = ipxResponse.ParseCollectionIO();
        IEnumerable<OutputResponse> outputResponses = parsedResponse.Where(o => o.Id >= MinId && o.Id <= MaxId).Select(o => new OutputResponseIPX800V5
        {
            Type = OutputType,
            State = o.On ? OutputState.Active : OutputState.Inactive,
            Number = o.Id,
            Name = o.Name,
            Link0 = o.Link0,
            Link1 = o.Link1
        });

        return outputResponses;
    }
}