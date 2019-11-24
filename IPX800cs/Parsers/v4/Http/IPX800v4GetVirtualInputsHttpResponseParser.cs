using System;
using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetVirtualInputsHttpResponseParser : IInputsResponseParser
    {
        public Dictionary<int, InputState> ParseResponse(string ipxResponse)
        {
            JObject json = JObject.Parse(ipxResponse);
            
            Dictionary<int, InputState> inputStates = json.Properties()
                .Where(p => p.Name.StartsWith("VI"))
                .ToDictionary(p => int.Parse(p.Name.Substring(2)), p => (InputState)(int)p.Value);

            return inputStates;
        }
    }
}