namespace software.elendil.IPX800.Parsers
{
    public interface IResponseParserFactoryProvider
    {
        IResponseParserFactory GetResponseParserFactory(Context context);
    }
}