using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.Http;

internal class IPX800v3GetInputsHttpResponseParser : IInputsResponseParser
{
    public IEnumerable<InputResponse> ParseResponse(string ipxResponse)
    {
        Dictionary<int, int> inputStates = JsonParser.ParseCollection(ipxResponse, "IN");
        return inputStates.Select(pair => new InputResponse
        {
            Type = InputType.DigitalInput,
            Number = pair.Key,
            Name = $"Input {pair.Key}",
            State = (InputState)pair.Value
        });
    }
}