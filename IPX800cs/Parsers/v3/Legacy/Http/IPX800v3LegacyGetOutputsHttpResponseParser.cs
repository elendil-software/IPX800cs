using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.Legacy.Http
{
    internal class IPX800v3LegacyGetOutputsHttpResponseParser : IGetOutputsResponseParser
    {
        public Dictionary<int, OutputState> ParseResponse(string ipxResponse)
        {
            XDocument xmlDoc = XDocument.Parse(ipxResponse);
            Dictionary<int, OutputState> inputStates = xmlDoc.Element("response").Elements()
                .Where(e => e.Name.LocalName.StartsWith("led"))
                .ToDictionary(e => int.Parse(e.Name.LocalName.Substring(3))+1, e => (OutputState)int.Parse(e.Value));

            return inputStates;
        }
    }
}