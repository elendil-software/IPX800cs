namespace software.elendil.IPX800.Parsers.v3.Http
{
    internal class IPX800v3SetOutputHttpResponseParser : ISetOutputResponseParser
    {
        public bool ParseResponse(string ipxResponse)
        {
            return ipxResponse?.Trim() == "OK";
        }
    }
}