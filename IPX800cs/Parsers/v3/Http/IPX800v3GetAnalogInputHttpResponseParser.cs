using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v3.Http
{
    internal class IPX800v3GetAnalogInputHttpResponseParser : IAnalogInputResponseParser
    {
        public int ParseResponse(string ipxResponse, int inputNumber)
        {
            Dictionary<int, int> response = GetAnalogInputs(ipxResponse);
            return response[inputNumber];
        }

        private Dictionary<int, int> GetAnalogInputs(string ipxResponse)
        {
            try
            {
                JObject json = JObject.Parse(ipxResponse);

                Dictionary<int, int> inputStates = json.Properties()
                    .Where(p => p.Name.StartsWith("AN"))
                    .ToDictionary(p => int.Parse(p.Name.Substring(2)), p => (int) p.Value);

                return inputStates;
            }
            catch (JsonReaderException ex)
            {
                throw new IPX800InvalidResponseException($"Unable to parse '{ipxResponse}' response", ex);
            }
        }
    }
}