using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.Http
{
    internal class IPX800v3GetInputsHttpResponseParser : IInputsResponseParser
    {
        public Dictionary<int, InputState> ParseResponse(string ipxResponse)
        {
            Dictionary<int, int> inputStates = JsonParser.ParseCollection(ipxResponse, "IN");
            return inputStates.ToDictionary(item => item.Key, item => (InputState) item.Value);
        }
    }
}