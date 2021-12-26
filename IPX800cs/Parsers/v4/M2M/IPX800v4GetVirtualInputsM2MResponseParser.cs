using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.M2M;

internal class IPX800v4GetVirtualInputsM2MResponseParser : ResponseParserBase, IInputsResponseParser
{
    public IEnumerable<InputResponse> ParseResponse(string ipxResponse)
    {
        ipxResponse = ipxResponse?.Replace("VI=", "");
        Dictionary<int, int> inputStates = ParseCollection(ipxResponse, "VI");
        return inputStates.Select(pair => new InputResponse
        {
            Type = InputType.VirtualDigitalInput,
            Number = pair.Key,
            Name = $"Virtual Input {pair.Key}",
            State = (InputState)pair.Value
        });
    }
}