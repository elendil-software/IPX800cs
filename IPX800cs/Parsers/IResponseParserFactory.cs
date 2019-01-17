using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers
{
    public interface IResponseParserFactory
    {
        IInputResponseParser<InputState> GetInputParser(Context context, IPX800Input input);
    }
}