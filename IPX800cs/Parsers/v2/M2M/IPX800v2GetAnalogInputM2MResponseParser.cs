using IPX800cs.Parsers.v3.Legacy.M2M;

namespace IPX800cs.Parsers.v2.M2M
{
    internal class IPX800v2GetAnalogInputM2MResponseParser : IPX800v2M2MParserBase, IAnalogInputResponseParser
    {
        public int ParseResponse(string ipxResponse, int inputNumber)
        {
            ipxResponse.CheckResponse();
            return ParseValue(ipxResponse);
        }
    }
}