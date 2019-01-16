using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers.v4.M2M
{
    public class VirtualInputResponseParser : NonHeadedResponseParserBase, IResponseParser<InputState, string>
    {
        public InputState ParseResponse(string ipxResponse, int ioNumber)
        {
            ipxResponse = ipxResponse.Replace("VI=", "");
            var result = ExtractValue(ipxResponse, ioNumber);
            return (InputState)System.Enum.Parse(typeof(InputState), result);
        }
    }
}