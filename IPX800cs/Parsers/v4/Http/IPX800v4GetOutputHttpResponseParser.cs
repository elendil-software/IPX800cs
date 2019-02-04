using System;
using Newtonsoft.Json.Linq;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers.v4.Http
{
    internal class IPX800v4GetOutputHttpResponseParser : IGetOutputResponseParser
    {
        public OutputState ParseResponse(string ipxResponse, int outputNumber)
        {
            JObject json = JObject.Parse(ipxResponse);
            string key = $"R{outputNumber}";
            string outputStateString = (string)json[key];
            return (OutputState)Enum.Parse(typeof(OutputState), outputStateString);
        }
    }
}