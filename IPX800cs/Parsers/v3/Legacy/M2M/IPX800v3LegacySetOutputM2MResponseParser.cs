namespace software.elendil.IPX800.Parsers.v3.Legacy.M2M
{
    public class IPX800v3LegacySetOutputM2MResponseParser : ISetOutputResponseParser
    {
        public bool ParseResponse(string ipxResponse)
        {
            return ipxResponse?.Trim() == "Success";
        }
    }
}