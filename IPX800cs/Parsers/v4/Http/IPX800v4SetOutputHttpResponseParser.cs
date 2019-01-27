using Newtonsoft.Json.Linq;

namespace software.elendil.IPX800.Parsers.v4.Http
{
    public class IPX800v4SetOutputHttpResponseParser : ISetOutputResponseParser
    {
        public bool ParseResponse(string ipxResponse)
        {
            JObject json = JObject.Parse(ipxResponse);
            return json["status"].ToString() == "Success";
        }
    }
}