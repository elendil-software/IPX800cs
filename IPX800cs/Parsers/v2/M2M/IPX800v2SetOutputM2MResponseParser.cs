namespace software.elendil.IPX800.Parsers.v2.M2M
{
    public class IPX800v2SetOutputM2MResponseParser : ISetOutputResponseParser
    {
        public bool ParseResponse(string ipxResponse)
        {
            return ipxResponse?.Trim() == "Success";
        }
    }
}