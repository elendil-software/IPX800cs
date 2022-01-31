using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v5;

public class IPX800V5GetInputsResponseParser : IGetInputsResponseParser
{
    public IEnumerable<InputResponse> ParseResponse(string ipxResponse)
    {
        IEnumerable<IOResponse> parsedResponse = ipxResponse.ParseCollectionIO();
        IEnumerable<InputResponse> outputResponses = parsedResponse.Where(o => o.Id is >= 65552 and <= 65559).Select(o => new InputResponse
        {
            Type = InputType.DigitalInput,
            State = o.On ? InputState.Active : InputState.Inactive,
            Number = o.Id,
            Name = o.Name
        });

        return outputResponses;
    }
}