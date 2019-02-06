using System.Linq;
using System.Xml.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v2.Http
{
    internal class IPX800v2GetOutputHttpResponseParser : IGetOutputResponseParser
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