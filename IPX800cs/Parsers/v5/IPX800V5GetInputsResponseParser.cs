using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v5;

public class IPX800V5GetInputsResponseParser : IGetInputsResponseParser
{
    protected int MinId;
    protected int MaxId;
    protected InputType InputType;

    public IPX800V5GetInputsResponseParser()
    {
        MinId = 65552;
        MaxId = 65559;
        InputType = InputType.DigitalInput;
    }

    public IEnumerable<InputResponse> ParseResponse(string ipxResponse)
    {
        IEnumerable<IOResponse> parsedResponse = ipxResponse.ParseCollectionIO();
        IEnumerable<InputResponse> outputResponses = parsedResponse.Where(o => o.Id >= MinId && o.Id <= MaxId).Select(o => new InputResponse
        {
            Type = InputType,
            State = o.On ? InputState.Active : InputState.Inactive,
            Number = o.Id,
            Name = o.Name
        });

        return outputResponses;
    }
}