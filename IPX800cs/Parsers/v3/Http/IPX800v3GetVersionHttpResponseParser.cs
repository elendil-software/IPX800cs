using System.Linq;
using System.Xml.Linq;

namespace software.elendil.IPX800.Parsers.v3.Http
{
    internal class IPX800v3GetVersionHttpResponseParser : IGetVersionResponseParser
    {
        public string ParseResponse(string ipxResponse)
        {
            XDocument xmlDoc = XDocument.Parse(ipxResponse);
            return xmlDoc.Element("response").Elements("version").First().Value;
        }
    }
}