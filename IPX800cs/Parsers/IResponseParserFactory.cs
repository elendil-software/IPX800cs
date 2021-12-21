using IPX800cs.IO;

namespace IPX800cs.Parsers;

public interface IResponseParserFactory
{
    IAnalogInputResponseParser GetAnalogInputParser(IPX800Protocol protocol, InputType inputType);
    IAnalogInputsResponseParser GetAnalogInputsParser(IPX800Protocol protocol, InputType inputType);
    IInputResponseParser GetInputParser(IPX800Protocol protocol, InputType inputType);
    IInputsResponseParser GetInputsParser(IPX800Protocol protocol, InputType inputType);
    IGetOutputResponseParser GetOutputParser(IPX800Protocol protocol, OutputType outputType);
    IGetOutputsResponseParser GetOutputsParser(IPX800Protocol protocol, OutputType outputType);
    ISetOutputResponseParser GetSetOutputParser(IPX800Protocol protocol);
}