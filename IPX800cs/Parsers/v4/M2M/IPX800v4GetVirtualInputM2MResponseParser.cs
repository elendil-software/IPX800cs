using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.M2M
{
    internal class IPX800v4GetVirtualInputM2MResponseParser : ResponseParserBase, IInputResponseParser
    {
        public InputState ParseResponse(string ipxResponse, int inputNumber)
        {
            ipxResponse = ipxResponse.Replace("VI=", "");
            var result = ExtractValue(ipxResponse, inputNumber);
            return (InputState)System.Enum.Parse(typeof(InputState), result);
        }
    }
}