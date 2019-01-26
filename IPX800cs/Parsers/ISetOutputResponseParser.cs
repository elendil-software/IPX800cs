namespace software.elendil.IPX800.Parsers
{
    public interface ISetOutputResponseParser
    {
        bool ParseResponse(string ipxResponse);
    }
}