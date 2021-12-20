using System;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.M2M;

internal class IPX800v3GetOutputM2MResponseParser : IGetOutputResponseParser
{
    public OutputState ParseResponse(string ipxResponse, int outputNumber)
    {
        ipxResponse.CheckResponse();
        var result = ipxResponse.Trim();
        return (OutputState) Enum.Parse(typeof(OutputState), result);
    }
}