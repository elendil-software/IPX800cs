namespace software.elendil.IPX800.Parsers
{
    public interface IGetVersionResponseParser
    {
        string ParseResponse(string ipxResponse);
    }
}