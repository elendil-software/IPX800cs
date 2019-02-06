using System.Linq;
using System.Xml.Linq;

namespace IPX800cs.Parsers.v3.Http
{
    internal class IPX800v3GetAnalogInputHttpResponseParser : IAnalogInputResponseParser
    {
        public double ParseResponse(string ipxResponse, int inputNumber)
        {
            inputNumber--;
            XDocument xmlDoc = XDocument.Parse(ipxResponse);
            string value = xmlDoc.Element("response").Elements($"analog{inputNumber}").First().Value;
            return double.Parse(value);
        }
    }
}