using IPX800cs.IO;

namespace IPX800cs.Parsers.v2.M2M;

internal class IPX800V2GetOutputM2MResponseParser : IPX800V2M2MParserBase, IGetOutputResponseParser
{
    public OutputState ParseResponse(string ipxResponse, int outputNumber)
    {
        ipxResponse.CheckResponse();
        int value = ParseValue(ipxResponse);
        return (OutputState) value;
    }
}