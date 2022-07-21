namespace IPX800cs.Parsers;
#pragma warning disable CS1591

public interface ISetOutputResponseParser
{
    bool ParseResponse(string ipxResponse);
}