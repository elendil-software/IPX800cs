using IPX800cs.Exceptions;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4SetOutputHttpResponseParser : ISetOutputResponseParser
    {
        public bool ParseResponse(string ipxResponse)
        {
            JObject json = JsonParser.Parse(ipxResponse);

            if (json.ContainsKey("status"))
            {
                return json["status"]?.ToString() == "Success";
            }
            else
            {
                throw new IPX800InvalidResponseException(ipxResponse);
            }
        }
    }
}