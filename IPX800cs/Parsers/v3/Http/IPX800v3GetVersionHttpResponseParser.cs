using System;
using System.Linq;
using System.Xml.Linq;
using IPX800cs.Exceptions;

namespace IPX800cs.Parsers.v3.Http
{
    internal class IPX800v3GetVersionHttpResponseParser : IGetVersionResponseParser
    {
        public string ParseResponse(string ipxResponse)
        {
            try
            {
                XDocument xmlDoc = XDocument.Parse(ipxResponse);
                return xmlDoc.Element("response").Elements("version").First().Value;
            }
            catch (Exception ex)
            {
                throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response", ex);
            }
        }
    }
}