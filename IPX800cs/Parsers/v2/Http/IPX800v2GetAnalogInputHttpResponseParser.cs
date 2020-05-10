using System;
using System.Linq;
using System.Xml.Linq;
using IPX800cs.Exceptions;

namespace IPX800cs.Parsers.v2.Http
{
    internal class IPX800v2GetAnalogInputHttpResponseParser : IAnalogInputResponseParser
    {
        public int ParseResponse(string ipxResponse, int inputNumber)
        {
            try
            {
                XDocument xmlDoc = XDocument.Parse(ipxResponse);
                string value = xmlDoc.Element("response").Elements($"an{inputNumber}").First().Value;
                return int.Parse(value);
            }
            catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
            {
                throw new IPX800InvalidResponseException($"Unable to parse '{ipxResponse}' response", ex);
            }
        }
    }
}