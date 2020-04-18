using System;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetOutputHttpResponseParser : IGetOutputResponseParser
    {
        public OutputState ParseResponse(string ipxResponse, int outputNumber)
        {
            try
            {
                JObject json = JObject.Parse(ipxResponse);
                string key = $"R{outputNumber}";
                string outputStateString = (string) json[key];
                return (OutputState) Enum.Parse(typeof(OutputState), outputStateString);
            }
            catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
            {
                throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response", ex);
            }
        }
    }
}