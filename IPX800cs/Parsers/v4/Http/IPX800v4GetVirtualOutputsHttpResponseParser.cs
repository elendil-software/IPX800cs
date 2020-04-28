using System;
using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetVirtualOutputsHttpResponseParser : IGetOutputsResponseParser
    {
        public Dictionary<int, OutputState> ParseResponse(string ipxResponse)
        {
            try
            {
                JObject json = JsonParser.Parse(ipxResponse);

                Dictionary<int, OutputState> outputStates = json.Properties()
                    .Where(p => p.Name.StartsWith("VO"))
                    .ToDictionary(p => int.Parse(p.Name.Substring(2)), p => (OutputState) (int) p.Value);

                return outputStates;
            }
            catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
            {
                throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response", ex);
            }
        }
    }
}