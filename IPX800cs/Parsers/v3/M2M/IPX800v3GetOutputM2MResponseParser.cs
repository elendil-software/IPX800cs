using System;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers.v3.M2M
{
    internal class IPX800v3GetOutputM2MResponseParser : IGetOutputResponseParser
    {
        public OutputState ParseResponse(string ipxResponse, int outputNumber)
        {
            var result = ipxResponse.Trim();
            return (OutputState)Enum.Parse(typeof(OutputState), result);
        }
    }
}