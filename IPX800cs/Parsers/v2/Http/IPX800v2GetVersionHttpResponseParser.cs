using System;
using System.Linq;
using System.Xml.Linq;
using IPX800cs.Exceptions;

namespace IPX800cs.Parsers.v2.Http
{
    internal class IPX800v2GetVersionHttpResponseParser : IGetVersionResponseParser
    {
        public string ParseResponse(string ipxResponse)
        {
            try
            {
                XDocument xmlDoc = XDocument.Parse(ipxResponse);
                return xmlDoc.Element("response").Elements("firmware_version").First().Value;
            }
            catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
            {
                throw new IPX800InvalidResponseException($"Unable to parse '{ipxResponse}' response", ex);
            }
        }
    }
}