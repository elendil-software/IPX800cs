using System;
using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v3.Http
{
    internal class IPX800v3GetAnalogInputHttpResponseParser : IAnalogInputResponseParser
    {
        public int ParseResponse(string ipxResponse, int inputNumber)
        {
            try
            {
                Dictionary<int, int> response = GetAnalogInputs(ipxResponse);
                return response[inputNumber];
            }
            catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
            {
                throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response", ex);
            }
        }

        private Dictionary<int, int> GetAnalogInputs(string ipxResponse)
        {
            JObject json = JsonParser.Parse(ipxResponse);

            Dictionary<int, int> inputStates = json.Properties()
                .Where(p => p.Name.StartsWith("AN"))
                .ToDictionary(p => int.Parse(p.Name.Substring(2)), p => (int) p.Value);

            return inputStates;
        }
    }
}