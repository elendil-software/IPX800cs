using System;
using IPX800cs.IO;
using IPX800cs.Parsers.v3.Legacy.M2M;

namespace IPX800cs.Parsers.v2.M2M
{
    internal class IPX800v2GetInputM2MResponseParser : IInputResponseParser
    {
        public InputState ParseResponse(string ipxResponse, int inputNumber)
        {
            ipxResponse.CheckResponse();
            var result = ipxResponse.Trim().Split('=')[1];
            return (InputState)Enum.Parse(typeof(InputState), result);
        }
    }
}