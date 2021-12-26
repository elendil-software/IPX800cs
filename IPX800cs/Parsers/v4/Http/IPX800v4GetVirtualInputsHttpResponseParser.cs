using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.Http;

internal class IPX800v4GetVirtualInputsHttpResponseParser : IInputsResponseParser
{
    public IEnumerable<InputResponse> ParseResponse(string ipxResponse)
    {
        Dictionary<int, int> inputStates = JsonParser.ParseCollection(ipxResponse, "VI");
        return inputStates.Select(pair => new InputResponse
        {
            Type = InputType.DigitalInput,
            Number = pair.Key,
            Name = $"Virtual Input {pair.Key}",
            State = (InputState)pair.Value
        });
    }
}