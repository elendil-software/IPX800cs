using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v5;

public class IPX800V5GetVirtualInputsResponseParser : IGetInputsResponseParser
{
    public IEnumerable<InputResponse> ParseResponse(string ipxResponse)
    {
        IEnumerable<IOResponse> parsedResponse = ipxResponse.ParseCollectionIO();
        IEnumerable<InputResponse> inputResponses = parsedResponse
            .Where(o => o.Virtual)
            .Select(o => new InputResponse
            {
                Type = InputType.VirtualDigitalInput,
                State = o.On ? InputState.Active : InputState.Inactive,
                Number = o.Id,
                Name = o.Name
            });

        return inputResponses;
    }
}