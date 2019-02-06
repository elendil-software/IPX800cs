using System;
using IPX800cs.IO;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetVirtualInputHttpResponseParser : IInputResponseParser
    {
        public InputState ParseResponse(string ipxResponse, int inputNumber)
        {
            JObject json = JObject.Parse(ipxResponse);
            string key = $"VI{inputNumber}";
            string inputStateString = json[key].ToString();
            return (InputState)Enum.Parse(typeof(InputState), inputStateString);
        }
    }
}