using System.Linq;
using System.Xml.Linq;

namespace IPX800cs.Parsers.v2.Http
{
    internal class IPX800v2GetVersionHttpResponseParser : IGetVersionResponseParser
    {
        public string ParseResponse(string ipxResponse)
        {
            XDocument xmlDoc = XDocument.Parse(ipxResponse);
            return xmlDoc.Element("response").Elements("firmware_version").First().Value;
        }
    }
}