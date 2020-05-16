using System.Collections.Generic;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetAnalogInputsHttpResponseParser : IAnalogInputsResponseParser
    {
        public Dictionary<int, int> ParseResponse(string ipxResponse)
        {
            return JsonParser.ParseCollection(ipxResponse, "A");
        }
    }
}