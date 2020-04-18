using System;
using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetInputsHttpResponseParser : IInputsResponseParser
    {
        public Dictionary<int, InputState> ParseResponse(string ipxResponse)
        {
            try
            {
                JObject json = JObject.Parse(ipxResponse);

                if (json.Count == 0)
                {
                    throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response");
                }

                Dictionary<int, InputState> inputStates = json.Properties()
                    .Where(p => p.Name.StartsWith("D"))
                    .ToDictionary(p => int.Parse(p.Name.Substring(1)), p => (InputState) (int) p.Value);

                return inputStates;
            }
            catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
            {
                throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response", ex);
            }
        }
    }
}