using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetAnalogInputsHttpResponseParser : IAnalogInputsResponseParser
    {
        public Dictionary<int, int> ParseResponse(string ipxResponse)
        {
            JObject json = JObject.Parse(ipxResponse);
            
            Dictionary<int, int> inputStates = json.Properties()
                .Where(p => p.Name.StartsWith("A"))
                .ToDictionary(p => int.Parse(p.Name.Substring(1)), p => (int)p.Value);

            return inputStates;
        }
    }
}