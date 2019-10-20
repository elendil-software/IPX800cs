using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v3.Http
{
    internal class IPX800v3GetOutputsHttpResponseParser : IGetOutputsResponseParser
    {
        public Dictionary<int, OutputState> ParseResponse(string ipxResponse)
        {
            JObject json = JObject.Parse(ipxResponse);
            
            Dictionary<int, OutputState> outputStates = json.Properties()
                .Where(p => p.Name.StartsWith("OUT"))
                .ToDictionary(p => int.Parse(p.Name.Substring(3)), p => (OutputState)(int)p.Value);

            return outputStates;
        }
    }
}