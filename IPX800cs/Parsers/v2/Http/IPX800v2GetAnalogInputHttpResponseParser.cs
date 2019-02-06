using System.Linq;
using System.Xml.Linq;

namespace IPX800cs.Parsers.v2.Http
{
    internal class IPX800v2GetAnalogInputHttpResponseParser : IAnalogInputResponseParser
    {
        public double ParseResponse(string ipxResponse, int inputNumber)
        {
            XDocument xmlDoc = XDocument.Parse(ipxResponse);
            string value = xmlDoc.Element("response").Elements($"an{inputNumber}").First().Value;
            return double.Parse(value);
        }
    }
}