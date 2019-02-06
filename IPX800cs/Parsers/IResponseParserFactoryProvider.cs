namespace IPX800cs.Parsers
{
    public interface IResponseParserFactoryProvider
    {
        IResponseParserFactory GetResponseParserFactory(Context context);
    }
}