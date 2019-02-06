namespace IPX800cs.Parsers.v2.M2M
{
    internal class IPX800v2SetOutputM2MResponseParser : ISetOutputResponseParser
    {
        public bool ParseResponse(string ipxResponse)
        {
            return ipxResponse?.Trim() == "Success";
        }
    }
}