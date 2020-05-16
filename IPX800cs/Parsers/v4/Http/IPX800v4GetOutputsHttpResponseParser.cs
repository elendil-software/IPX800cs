using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetOutputsHttpResponseParser : IGetOutputsResponseParser
    {
        public Dictionary<int, OutputState> ParseResponse(string ipxResponse)
        {
            Dictionary<int, int> inputStates = JsonParser.ParseCollection(ipxResponse, "R");
            return inputStates.ToDictionary(item => item.Key, item => (OutputState) item.Value);
        }
    }
}