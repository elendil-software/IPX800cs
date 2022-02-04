using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v2.Http;
using IPX800cs.Parsers.v2.M2M;

namespace IPX800cs.Parsers.v2;

internal class IPX800v2ResponseParserFactory : IResponseParserFactory
{
    public IGetInputResponseParser CreateGetInputParser(IPX800Protocol protocol, InputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpInputParser(inputType),
            IPX800Protocol.M2M => CreateGetM2MInputParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v2")
        };
    }
    private IGetInputResponseParser CreateGetHttpInputParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => new IPX800V2GetGetInputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v2")
        };
    }
    private IGetInputResponseParser CreateGetM2MInputParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => new IPX800V2GetGetInputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v2")
        };
    }

    public IGetInputsResponseParser CreateGetInputsParser(IPX800Protocol protocol, InputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpInputsParser(inputType),
            IPX800Protocol.M2M => throw new IPX800NotSupportedCommandException("Get Inputs Parser with protocol M2M is not supported by IPX800 v2, use CreateGetInputParser for each input"),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v2")
        };
    }
    private IGetInputsResponseParser CreateGetHttpInputsParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => new IPX800V2GetGetInputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v2")
        };
    }
    
    public IGetAnalogInputResponseParser CreateGetAnalogInputParser(IPX800Protocol protocol, AnalogInputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpAnalogInputParser(inputType),
            IPX800Protocol.M2M => CreateGetM2MAnalogInputParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v2")
        };
    }
    private IGetAnalogInputResponseParser CreateGetHttpAnalogInputParser(AnalogInputType inputType)
    {
        return inputType switch
        {
            AnalogInputType.AnalogInput => new IPX800V2GetGetAnalogInputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v2")
        };
    }
    private IGetAnalogInputResponseParser CreateGetM2MAnalogInputParser(AnalogInputType inputType)
    {
        return inputType switch
        {
            AnalogInputType.AnalogInput => new IPX800V2GetGetAnalogInputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v2")
        };
    }
    
    public IAnalogInputsResponseParser CreateGetAnalogInputsParser(IPX800Protocol protocol, AnalogInputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpAnalogInputsParser(inputType),
            IPX800Protocol.M2M => throw new IPX800NotSupportedCommandException("Get Analog Inputs Parser with protocol M2M is not supported by IPX800 v2, use CreateGetAnalogInputParser for each input"),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v2")
        };
    }
    
    private IAnalogInputsResponseParser CreateGetHttpAnalogInputsParser(AnalogInputType inputType)
    {
        return inputType switch
        {
            AnalogInputType.AnalogInput => new IPX800v2GetAnalogInputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v2")
        };
    }

    public IGetOutputResponseParser CreateGetOutputParser(IPX800Protocol protocol, OutputType outputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpOutputParser(outputType),
            IPX800Protocol.M2M => CreateGetM2MOutputParser(outputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v2")
        };
    }
    private IGetOutputResponseParser CreateGetHttpOutputParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800v2GetOutputHttpResponseParser(),
            OutputType.DelayedOutput => new IPX800v2GetOutputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v2")
        };
    }
    private IGetOutputResponseParser CreateGetM2MOutputParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800v2GetOutputM2MResponseParser(),
            OutputType.DelayedOutput => new IPX800v2GetOutputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v2")
        };
    }

    public IGetOutputsResponseParser CreateGetOutputsParser(IPX800Protocol protocol, OutputType outputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpOutputsParser(outputType),
            IPX800Protocol.M2M => throw new IPX800NotSupportedCommandException("Get Outputs Parser with protocol M2M is not supported by IPX800 v2, use CreateGetOutputParser for each output"),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v2")
        };
    }
    private IGetOutputsResponseParser CreateGetHttpOutputsParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800v2GetOutputsHttpResponseParser(),
            OutputType.DelayedOutput => new IPX800v2GetOutputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v2")
        };
    }

    public ISetOutputResponseParser CreateSetOutputParser(IPX800Protocol protocol)
    {
        return protocol switch
        {
            IPX800Protocol.Http => new IPX800v2SetOutputHttpResponseParser(),
            IPX800Protocol.M2M => new IPX800v2SetOutputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v2")
        };
    }
}