namespace IPX800cs.Parsers.v3.M2M;

internal class IPX800v3SetOutputM2MResponseParser : ISetOutputResponseParser
{
    public bool ParseResponse(string ipxResponse)
    {
        return ipxResponse?.Trim() == "OK";
    }
}