using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4SetOutputHttpResponseParser : ISetOutputResponseParser
    {
        public bool ParseResponse(string ipxResponse)
        {
            JObject json = JObject.Parse(ipxResponse);
            return json["status"].ToString() == "Success";
        }
    }
}