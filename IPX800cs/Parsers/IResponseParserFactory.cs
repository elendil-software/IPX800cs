using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers
{
    public interface IResponseParserFactory
    {
        IInputResponseParser GetInputParser(Context context, Input input);
    }
}