using System;
using System.Linq;
using System.Xml.Linq;

namespace software.elendil.IPX800.Parsers.v3.Http
{
    public class IPX800v3AnalogInputHttpResponseParser : IAnalogInputResponseParser
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