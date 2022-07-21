namespace IPX800cs.Parsers.v5;

internal interface IIPX800V5ResponseParserFactory : IResponseParserFactory
{
    IGetTimersResponseParser CreateGetTimersParser();
}