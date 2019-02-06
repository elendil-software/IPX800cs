namespace IPX800cs.Parsers.v3.M2M
{
    internal class IPX800v3GetVersionM2MResponseParser : IGetVersionResponseParser
    {
        public string ParseResponse(string ipxResponse)
        {
            return ipxResponse.Trim();
        }
    }
}