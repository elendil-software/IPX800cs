namespace IPX800cs.Parsers.v4.M2M
{
    internal class IPX800v4SetOutputM2MResponseParser : ISetOutputResponseParser
    {
        public bool ParseResponse(string ipxResponse)
        {
            return ipxResponse.Trim() == "Success";
        }
    }
}