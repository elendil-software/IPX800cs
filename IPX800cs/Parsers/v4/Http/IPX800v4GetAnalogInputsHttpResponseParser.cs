using System;
using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetAnalogInputsHttpResponseParser : IAnalogInputsResponseParser
    {
        public Dictionary<int, int> ParseResponse(string ipxResponse)
        {
            try
            {
                JObject json = JsonParser.Parse(ipxResponse);
                
                Dictionary<int, int> inputStates = json.Properties()
                    .Where(p => p.Name.StartsWith("A"))
                    .ToDictionary(p => int.Parse(p.Name.Substring(1)), p => (int) p.Value);

                return inputStates;
            }
            catch (Exception ex) when(!(ex is IPX800InvalidResponseException))
            {
                throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response", ex);
            }
        }
    }
}