using System;
using System.Linq;
using System.Xml.Linq;

namespace software.elendil.IPX800.Parsers.v2.Http
{
    public class IPX800v2GetAnalogInputHttpResponseParser : IAnalogInputResponseParser
    {
        public double ParseResponse(string ipxResponse, int inputNumber)
        {
            XDocument xmlDoc = XDocument.Parse(ipxResponse);
            string value = xmlDoc.Element("response").Elements($"an{inputNumber}").First().Value;
            return double.Parse(value);
        }
    }
}