using System;
using Newtonsoft.Json.Linq;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers.v4.Http
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