using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.M2M
{
    internal class IPX800v4GetInputsM2MResponseParser : ResponseParserBase, IInputsResponseParser
    {
        public Dictionary<int, InputState> ParseResponse(string ipxResponse)
        {
            Dictionary<int, int> inputStates = ParseCollection(ipxResponse, "D");
            return inputStates.ToDictionary(item => item.Key, item => (InputState) item.Value);
        }
    }
}