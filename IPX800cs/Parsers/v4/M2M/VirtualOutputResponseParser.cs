using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers.v4.M2M
{
    public class VirtualOutputResponseParser : NonHeadedResponseParserBase, IResponseParser<OutputState, string>
    {
        public OutputState ParseResponse(string ipxResponse, int ioNumber)
        {
            ipxResponse = ipxResponse.Replace("VO=", "");
            string result = ExtractValue(ipxResponse, ioNumber);
            return (OutputState) System.Enum.Parse(typeof(OutputState), result);
        }
    }
}