using System;
using IPX800cs.IO;
using IPX800cs.Parsers.v3.Legacy.M2M;

namespace IPX800cs.Parsers.v2.M2M
{
    internal class IPX800v2GetInputM2MResponseParser : IPX800v2M2MParserBase, IInputResponseParser
    {
        public InputState ParseResponse(string ipxResponse, int inputNumber)
        {
            ipxResponse.CheckResponse();
            int value = GetValue(ipxResponse);
            return (InputState) value;
        }
    }
}