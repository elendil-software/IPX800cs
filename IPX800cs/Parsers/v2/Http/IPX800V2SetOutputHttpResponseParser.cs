namespace IPX800cs.Parsers.v2.Http;

internal class IPX800V2SetOutputHttpResponseParser : ISetOutputResponseParser
{
    public bool ParseResponse(string ipxResponse)
    {
        return !string.IsNullOrWhiteSpace(ipxResponse);
    }
}