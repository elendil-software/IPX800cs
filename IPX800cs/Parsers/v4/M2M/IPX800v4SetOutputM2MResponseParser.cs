namespace software.elendil.IPX800.Parsers.v4.M2M
{
    public class IPX800v4SetOutputM2MResponseParser : ISetOutputResponseParser
    {
        public bool ParseResponse(string ipxResponse)
        {
            return ipxResponse.Trim() == "Success";
        }
    }
}