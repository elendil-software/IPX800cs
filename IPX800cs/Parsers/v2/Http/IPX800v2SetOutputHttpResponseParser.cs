namespace software.elendil.IPX800.Parsers.v2.Http
{
    public class IPX800v2SetOutputHttpResponseParser : ISetOutputResponseParser
    {
        public bool ParseResponse(string ipxResponse)
        {
            return ipxResponse?.Trim() == "OK";
        }
    }
}