using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.M2M;

internal class IPX800v4GetInputsM2MResponseParser : ResponseParserBase, IInputsResponseParser
{
    public IEnumerable<InputResponse> ParseResponse(string ipxResponse)
    {
        Dictionary<int, int> inputStates = ParseCollection(ipxResponse, "D");
        return inputStates.Select(pair => new InputResponse
        {
            Type = InputType.DigitalInput,
            Number = pair.Key,
            Name = $"Input {pair.Key}",
            State = (InputState)pair.Value
        });
    }
}