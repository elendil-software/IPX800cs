#pragma warning disable CS1591
namespace IPX800cs.Parsers.v5;

public interface IIPX800V5ResponseParserFactory : IResponseParserFactory
{
    IGetTimersResponseParser CreateGetTimersParser();
}