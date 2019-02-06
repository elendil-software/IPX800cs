using IPX800cs.IO;

namespace IPX800cs.Parsers
{
    public interface IResponseParserFactory
    {
        IGetVersionResponseParser GetVersionResponseParser(Context context);
        IAnalogInputResponseParser GetAnalogInputParser(Context context, Input input);
        IInputResponseParser GetInputParser(Context context, Input input);
        IGetOutputResponseParser GetOutputParser(Context context, Output input);
        ISetOutputResponseParser GetSetOutputParser(Context context, Output input);
    }
}