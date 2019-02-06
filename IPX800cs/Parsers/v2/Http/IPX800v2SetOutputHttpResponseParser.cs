namespace software.elendil.IPX800.Parsers.v2.Http
{
    internal class IPX800v2SetOutputHttpResponseParser : ISetOutputResponseParser
    {
        public bool ParseResponse(string ipxResponse)
        {
            return !string.IsNullOrWhiteSpace(ipxResponse);
        }
    }
}