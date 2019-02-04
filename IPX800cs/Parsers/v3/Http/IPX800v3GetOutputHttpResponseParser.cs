using System.Linq;
using System.Xml.Linq;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers.v3.Http
{
    internal class IPX800v3GetOutputHttpResponseParser : IGetOutputResponseParser
    {
        public OutputState ParseResponse(string ipxResponse, int outputNumber)
        {
            outputNumber--;
            XDocument xmlDoc = XDocument.Parse(ipxResponse);
            var stateString = xmlDoc.Element("response").Elements($"led{outputNumber}").FirstOrDefault().Value;
            return (OutputState) System.Enum.Parse(typeof(OutputState), stateString);
        }
    }
}