using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.M2M;

internal class IPX800V4GetGetInputM2MResponseParser : ResponseParserBase, IGetInputResponseParser
{
    public InputState ParseResponse(string ipxResponse, int inputNumber)
    {
        return (InputState) ParseValue(ipxResponse, inputNumber);
    }
}