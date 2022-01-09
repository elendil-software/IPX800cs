using System;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.M2M;

internal class IPX800V3GetGetInputM2MResponseParser : IGetInputResponseParser
{
    public InputState ParseResponse(string ipxResponse, int inputNumber)
    {
        ipxResponse.CheckResponse();
        var result = ipxResponse.Trim();
        return (InputState) Enum.Parse(typeof(InputState), result);
    }
}