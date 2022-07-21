namespace IPX800cs.Parsers.v5;

public interface IIPX800V5ResponseParserFactory : IResponseParserFactory
{
    IGetTimersResponseParser CreateGetTimersParser();
}