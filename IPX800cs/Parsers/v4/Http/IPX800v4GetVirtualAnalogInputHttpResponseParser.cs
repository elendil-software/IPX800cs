using System;
using IPX800cs.Exceptions;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetVirtualAnalogInputHttpResponseParser : IAnalogInputResponseParser
    {
        public int ParseResponse(string ipxResponse, int inputNumber)
        {
            try
            {
                JObject json = JsonParser.Parse(ipxResponse);
                string key = $"VA{inputNumber}";
                return int.Parse(json[key].ToString());
            }
            catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
            {
                throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response", ex);
            }
        }
    }
}