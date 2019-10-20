using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetInputsHttpResponseParser : IInputsResponseParser
    {
        public Dictionary<int, InputState> ParseResponse(string ipxResponse)
        {
            JObject json = JObject.Parse(ipxResponse);
            
            Dictionary<int, InputState> outputStates = json.Properties()
                .Where(p => p.Name.StartsWith("D"))
                .ToDictionary(p => int.Parse(p.Name.Substring(1)), p => (InputState)(int)p.Value);

            return outputStates;
        }
    }
}