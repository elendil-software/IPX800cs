using IPX800cs.IO;
#pragma warning disable CS1591

namespace IPX800cs.Parsers;

public interface IResponseParserFactory
{
    IGetInputResponseParser CreateGetInputParser(IPX800Protocol protocol, InputType inputType);
    IGetInputsResponseParser CreateGetInputsParser(IPX800Protocol protocol, InputType inputType);
    IGetAnalogInputResponseParser CreateGetAnalogInputParser(IPX800Protocol protocol, AnalogInputType inputType);
    IAnalogInputsResponseParser CreateGetAnalogInputsParser(IPX800Protocol protocol, AnalogInputType inputType);
    IGetOutputResponseParser CreateGetOutputParser(IPX800Protocol protocol, OutputType outputType);
    IGetOutputsResponseParser CreateGetOutputsParser(IPX800Protocol protocol, OutputType outputType);
    ISetOutputResponseParser CreateSetOutputParser(IPX800Protocol protocol);
}