using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.M2M
{
    internal class IPX800v4GetOutputsM2MResponseParser : ResponseParserBase, IGetOutputsResponseParser
    {
        public Dictionary<int, OutputState> ParseResponse(string ipxResponse)
        {
            Dictionary<int, int> outputStates = ParseCollection(ipxResponse, "R");
            return outputStates.ToDictionary(item => item.Key, item => (OutputState) item.Value);
        }
    }
}