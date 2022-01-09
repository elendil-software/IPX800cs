using IPX800cs.IO;

namespace IPX800cs.Parsers.v2.M2M;

internal class IPX800V2GetGetInputM2MResponseParser : IPX800v2M2MParserBase, IGetInputResponseParser
{
    public InputState ParseResponse(string ipxResponse, int inputNumber)
    {
        ipxResponse.CheckResponse();
        int value = ParseValue(ipxResponse);
        return (InputState) value;
    }
}