using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers.v4.M2M
{
    public class IPX800v4GetOutputM2MResponseParser : ResponseParserBase, IGetOutputResponseParser
    {
        public OutputState ParseResponse(string ipxResponse, int outputNumber)
        {
            string result = ExtractValue(ipxResponse, outputNumber);

            if (int.TryParse(result, out int value))
            {
                return (OutputState)value;
            }
            else
            {
                var splitedResult = result.Split('=');
                return (OutputState)int.Parse(splitedResult[1]);
            }
        }
    }
}