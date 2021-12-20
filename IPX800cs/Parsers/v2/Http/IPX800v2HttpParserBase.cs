using System.Linq;
using System.Xml.Linq;

namespace IPX800cs.Parsers.v2.Http;

internal abstract class IPX800v2HttpParserBase
{
    protected int ParseValue(string ipxResponse, string element)
    {
        XDocument xmlDoc = XDocument.Parse(ipxResponse);
        string value = xmlDoc.Element("response").Elements(element).First().Value;
        return int.Parse(value);
    }
}