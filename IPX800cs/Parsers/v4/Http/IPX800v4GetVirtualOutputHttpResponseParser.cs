using System;
using IPX800cs.IO;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetVirtualOutputHttpResponseParser : IGetOutputResponseParser
    {
        public OutputState ParseResponse(string ipxResponse, int outputNumber)
        {
            JObject json = JObject.Parse(ipxResponse);
            string key = $"VO{outputNumber}";
            string outputStateString = (string)json[key];
            return (OutputState)Enum.Parse(typeof(OutputState), outputStateString);
        }
    }
}