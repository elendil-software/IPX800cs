namespace software.elendil.IPX800.Parsers.v3.M2M
{
    public class IPX800v3GetVersionM2MResponseParser : IGetVersionResponseParser
    {
        public string ParseResponse(string ipxResponse)
        {
            return ipxResponse.Trim();
        }
    }
}