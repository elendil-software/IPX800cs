using System;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.M2M
{
    internal class IPX800v3GetInputM2MResponseParser : IInputResponseParser
    {
        public InputState ParseResponse(string ipxResponse, int inputNumber)
        {
            var result = ipxResponse.Trim();
            return (InputState)Enum.Parse(typeof(InputState), result);
        }
    }
}