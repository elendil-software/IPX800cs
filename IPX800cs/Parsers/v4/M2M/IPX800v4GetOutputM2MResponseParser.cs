using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.M2M
{
    internal class IPX800v4GetOutputM2MResponseParser : ResponseParserBase, IGetOutputResponseParser
    {
        public OutputState ParseResponse(string ipxResponse, int outputNumber)
        {
            return (OutputState) ParseValue(ipxResponse, outputNumber);
        }
    }
}