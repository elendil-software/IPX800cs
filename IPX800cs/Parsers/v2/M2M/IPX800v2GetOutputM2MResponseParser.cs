using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers.v2.M2M
{
    public class IPX800v2GetOutputM2MResponseParser : IGetOutputResponseParser
    {
        public OutputState ParseResponse(string ipxResponse, int outputNumber)
        {
            string result = ipxResponse.Trim().Split('=')[1];
            return (OutputState)System.Enum.Parse(typeof(OutputState), result);
        }
    }
}