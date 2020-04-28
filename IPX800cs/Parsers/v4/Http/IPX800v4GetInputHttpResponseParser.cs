using System;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetInputHttpResponseParser : IInputResponseParser
    {
        public InputState ParseResponse(string ipxResponse, int inputNumber)
        {
            try
            {
                JObject json = JsonParser.Parse(ipxResponse);
                string key = $"D{inputNumber}";
                string inputStateString = json[key].ToString();
                return (InputState) Enum.Parse(typeof(InputState), inputStateString);
            }
            catch (Exception ex)
            {
                throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response", ex);
            }
        }
    }
}