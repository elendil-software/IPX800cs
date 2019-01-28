using System;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers.v3.M2M
{
    public class IPX800v3GetInputM2MResponseParser : IInputResponseParser
    {
        public InputState ParseResponse(string ipxResponse, int inputNumber)
        {
            var result = ipxResponse.Trim();
            return (InputState)Enum.Parse(typeof(InputState), result);
        }
    }
}