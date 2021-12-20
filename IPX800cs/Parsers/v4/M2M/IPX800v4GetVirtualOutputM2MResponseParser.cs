using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.M2M;

internal class IPX800v4GetVirtualOutputM2MResponseParser : ResponseParserBase, IGetOutputResponseParser
{
    public OutputState ParseResponse(string ipxResponse, int outputNumber)
    {
        ipxResponse = ipxResponse?.Replace("VO=", "");
        return (OutputState) ParseValue(ipxResponse, outputNumber);
    }
}