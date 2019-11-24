using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetVirtualAnalogInputsHttpResponseParser : IAnalogInputsResponseParser
    {
        public Dictionary<int, int> ParseResponse(string ipxResponse)
        {
            JObject json = JObject.Parse(ipxResponse);

            Dictionary<int, int> inputStates = json.Properties()
                .Where(p => p.Name.StartsWith("VA"))
                .ToDictionary(p => int.Parse(p.Name.Substring(2)), p => (int) p.Value);

            return inputStates;
        }
    }
}