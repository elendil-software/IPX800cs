using IPX800cs.IO;

namespace IPX800cs.Parsers;

public interface IResponseParserFactory
{
    IInputResponseParser GetInputParser(IPX800Protocol protocol, InputType inputType);
    IInputsResponseParser GetInputsParser(IPX800Protocol protocol, InputType inputType);
    IAnalogInputResponseParser GetAnalogInputParser(IPX800Protocol protocol, AnalogInputType inputType);
    IAnalogInputsResponseParser GetAnalogInputsParser(IPX800Protocol protocol, AnalogInputType inputType);
    IGetOutputResponseParser GetOutputParser(IPX800Protocol protocol, OutputType outputType);
    IGetOutputsResponseParser GetOutputsParser(IPX800Protocol protocol, OutputType outputType);
    ISetOutputResponseParser GetSetOutputParser(IPX800Protocol protocol);
}