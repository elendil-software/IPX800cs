namespace IPX800cs.Parsers.v3.Legacy.M2M
{
    internal class IPX800v3LegacyGetVersionM2MResponseParser : IGetVersionResponseParser
    {
        public string ParseResponse(string ipxResponse)
        {
            var response = ipxResponse.Trim().Split('=');
            return response[1];
        }
    }
}