using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.M2M;

internal class IPX800v3GetOutputsM2MResponseParser : IGetOutputsResponseParser
{
    public IEnumerable<OutputResponse> ParseResponse(string ipxResponse)
    {
        ipxResponse.CheckResponse();
            
        var outputStates = new List<OutputResponse>();
        int outputNumber = 1;
            
        foreach (char c in ipxResponse.Trim())
        {
            outputStates.Add(new OutputResponse
            {
                Type = OutputType.Output,
                Number = outputNumber,
                Name = $"Output {outputNumber}",
                State = c == '1' ? OutputState.Active : OutputState.Inactive
            });
            
            outputNumber++;
        }
        return outputStates;
    }
}