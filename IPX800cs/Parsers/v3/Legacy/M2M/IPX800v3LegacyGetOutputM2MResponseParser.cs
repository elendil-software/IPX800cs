using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.Legacy.M2M
{
    internal class IPX800v3LegacyGetOutputM2MResponseParser : IGetOutputResponseParser
    {
        public OutputState ParseResponse(string ipxResponse, int outputNumber)
        {
            ipxResponse.CheckResponse();
            string result = ipxResponse.Trim().Split('=')[1];
            return (OutputState) System.Enum.Parse(typeof(OutputState), result);
        }
    }
}