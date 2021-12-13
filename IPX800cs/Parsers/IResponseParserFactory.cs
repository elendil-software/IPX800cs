using IPX800cs.IO;

namespace IPX800cs.Parsers
{
    public interface IResponseParserFactory
    {
        IAnalogInputResponseParser GetAnalogInputParser(Context context, Input input);
        IAnalogInputsResponseParser GetAnalogInputsParser(Context context, Input input);
        IInputResponseParser GetInputParser(Context context, Input input);
        IInputsResponseParser GetInputsParser(Context context, Input input);
        IGetOutputResponseParser GetOutputParser(Context context, Output output);
        IGetOutputsResponseParser GetOutputsParser(Context context, Output output);
        ISetOutputResponseParser GetSetOutputParser(Context context, Output output);
    }
}