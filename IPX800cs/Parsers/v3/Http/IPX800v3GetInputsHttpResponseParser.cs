using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v3.Http
{
    internal class IPX800v3GetInputsHttpResponseParser : IInputsResponseParser
    {
        public Dictionary<int, InputState> ParseResponse(string ipxResponse)
        {
            try
            {
                JObject json = JsonParser.Parse(ipxResponse);

                Dictionary<int, InputState> inputStates = json.Properties()
                    .Where(p => p.Name.StartsWith("IN"))
                    .ToDictionary(p => int.Parse(p.Name.Substring(2)), p => (InputState) (int) p.Value);

                return inputStates;
            }
            catch (JsonReaderException ex)
            {
                throw new IPX800InvalidResponseException($"Unable to parse '{ipxResponse}' response", ex);
            }
        }
    }
}