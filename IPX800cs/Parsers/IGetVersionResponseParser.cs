namespace IPX800cs.Parsers
{
    public interface IGetVersionResponseParser
    {
        string ParseResponse(string ipxResponse);
    }
}