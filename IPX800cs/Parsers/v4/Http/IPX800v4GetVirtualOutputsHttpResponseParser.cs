using System;
using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetVirtualOutputsHttpResponseParser : IGetOutputsResponseParser
    {
        public Dictionary<int, OutputState> ParseResponse(string ipxResponse)
        {
            JObject json = JObject.Parse(ipxResponse);

            Dictionary<int, OutputState> outputStates = json.Properties()
                .Where(p => p.Name.StartsWith("VO"))
                .ToDictionary(p => int.Parse(p.Name.Substring(2)), p => (OutputState) (int) p.Value);

            return outputStates;
        }
    }
}