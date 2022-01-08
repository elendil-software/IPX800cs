using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v2.Http;
using IPX800cs.Parsers.v2.M2M;

namespace IPX800cs.Parsers.v2;

internal class IPX800v2ResponseParserFactory : IResponseParserFactory
{
    public IInputResponseParser GetInputParser(IPX800Protocol protocol, InputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => GetHttpInputParser(inputType),
            IPX800Protocol.M2M => GetM2MInputParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v2")
        };
    }
    private IInputResponseParser GetHttpInputParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => new IPX800v2GetInputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v2")
        };
    }
    private IInputResponseParser GetM2MInputParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => new IPX800v2GetInputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v2")
        };
    }

    public IInputsResponseParser GetInputsParser(IPX800Protocol protocol, InputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => GetHttpInputsParser(inputType),
            IPX800Protocol.M2M => GetM2MInputsParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v2")
        };
    }
    private IInputsResponseParser GetM2MInputsParser(InputType inputType)
    {
        return inputType switch
        {
            //TODO to be implemented
            //InputType.DigitalInput => new IPX800v2GetInputsM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v2")
        };
    }
    private IInputsResponseParser GetHttpInputsParser(InputType inputType)
    {
        return inputType switch
        {
            //TODO to be implemented
            //InputType.DigitalInput => new IPX800v2GetInputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v2")
        };
    }
    
    public IAnalogInputResponseParser GetAnalogInputParser(IPX800Protocol protocol, AnalogInputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => GetHttpAnalogInputParser(inputType),
            IPX800Protocol.M2M => GetM2MAnalogInputParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v2")
        };
    }
    private IAnalogInputResponseParser GetHttpAnalogInputParser(AnalogInputType inputType)
    {
        return inputType switch
        {
            AnalogInputType.AnalogInput => new IPX800v2GetAnalogInputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v2")
        };
    }
    private IAnalogInputResponseParser GetM2MAnalogInputParser(AnalogInputType inputType)
    {
        return inputType switch
        {
            AnalogInputType.AnalogInput => new IPX800v2GetAnalogInputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v2")
        };
    }
    
    public IAnalogInputsResponseParser GetAnalogInputsParser(IPX800Protocol protocol, AnalogInputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => GetHttpAnalogInputsParser(inputType),
            IPX800Protocol.M2M => throw new IPX800NotSupportedCommandException("Get Analog Inputs Parser with protocol M2M is not supported by IPX800 v2, use GetAnalogInputParser for each input"),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v2")
        };
    }
    
    private IAnalogInputsResponseParser GetHttpAnalogInputsParser(AnalogInputType inputType)
    {
        return inputType switch
        {
            AnalogInputType.AnalogInput => new IPX800v2GetAnalogInputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v2")
        };
    }

    public IGetOutputResponseParser GetOutputParser(IPX800Protocol protocol, OutputType outputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => GetHttpOutputParser(outputType),
            IPX800Protocol.M2M => GetM2MOutputParser(outputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v2")
        };
    }
    private IGetOutputResponseParser GetHttpOutputParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800v2GetOutputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v2")
        };
    }
    private IGetOutputResponseParser GetM2MOutputParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800v2GetOutputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v2")
        };
    }

    public IGetOutputsResponseParser GetOutputsParser(IPX800Protocol protocol, OutputType outputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => GetHttpOutputsParser(outputType),
            IPX800Protocol.M2M => GetM2MOutputsParser(outputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v2")
        };
    }
    private IGetOutputsResponseParser GetHttpOutputsParser(OutputType outputType)
    {
        return outputType switch
        {
            //TODO to be implemented
            //OutputType.Output => new IPX800v2GetOutputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v2")
        };
    }
    private IGetOutputsResponseParser GetM2MOutputsParser(OutputType outputType)
    {
        return outputType switch
        {
            //TODO to be implemented
            //OutputType.Output => new IPX800v2GetOutputsM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v2")
        };
    }

    public ISetOutputResponseParser GetSetOutputParser(IPX800Protocol protocol)
    {
        return protocol switch
        {
            IPX800Protocol.Http => new IPX800v2SetOutputHttpResponseParser(),
            IPX800Protocol.M2M => new IPX800v2SetOutputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v2")
        };
    }
}