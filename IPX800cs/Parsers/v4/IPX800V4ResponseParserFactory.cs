using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.Http;
using IPX800cs.Parsers.v4.M2M;

namespace IPX800cs.Parsers.v4;

internal class IPX800V4ResponseParserFactory : IResponseParserFactory
{
    public IGetInputResponseParser CreateGetInputParser(IPX800Protocol protocol, InputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpInputParser(inputType),
            IPX800Protocol.M2M => CreateGetM2MInputParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v4")
        };
    }
    private IGetInputResponseParser CreateGetHttpInputParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.VirtualDigitalInput => new IPX800V4GetVirtualGetInputHttpResponseParser(),
            InputType.DigitalInput => new IPX800V4GetGetInputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v4")
        };
    }
    private IGetInputResponseParser CreateGetM2MInputParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.VirtualDigitalInput => new IPX800V4GetVirtualGetInputM2MResponseParser(),
            InputType.DigitalInput => new IPX800V4GetGetInputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v4")
        };
    }

    public IGetInputsResponseParser CreateGetInputsParser(IPX800Protocol protocol, InputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpInputsParser(inputType),
            IPX800Protocol.M2M => CreateGetM2MInputsParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v4")
        };
    }
    private IGetInputsResponseParser CreateGetM2MInputsParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.VirtualDigitalInput => new IPX800V4GetVirtualGetInputsM2MResponseParser(),
            InputType.DigitalInput => new IPX800V4GetGetInputsM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v4")
        };
    }
    private IGetInputsResponseParser CreateGetHttpInputsParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.VirtualDigitalInput => new IPX800V4GetVirtualGetInputsHttpResponseParser(),
            InputType.DigitalInput => new IPX800V4GetGetInputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v4")
        };
    }
 
    public IGetAnalogInputResponseParser CreateGetAnalogInputParser(IPX800Protocol protocol, AnalogInputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpAnalogInputParser(inputType),
            IPX800Protocol.M2M => CreateGetM2MAnalogInputParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v4")
        };
    }
    private IGetAnalogInputResponseParser CreateGetHttpAnalogInputParser(AnalogInputType inputType)
    {
        return inputType switch
        {
            AnalogInputType.VirtualAnalogInput => new IPX800V4GetVirtualGetAnalogInputHttpResponseParser(),
            AnalogInputType.AnalogInput => new IPX800V4GetGetAnalogInputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v4")
        };
    }
    private IGetAnalogInputResponseParser CreateGetM2MAnalogInputParser(AnalogInputType inputType)
    {
        return inputType switch
        {
            AnalogInputType.VirtualAnalogInput => new IPX800V4GetVirtualGetAnalogInputM2MResponseParser(),
            AnalogInputType.AnalogInput => new IPX800V4GetGetAnalogInputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v4")
        };
    }
    
    public IAnalogInputsResponseParser CreateGetAnalogInputsParser(IPX800Protocol protocol, AnalogInputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpAnalogInputsParser(inputType),
            IPX800Protocol.M2M => CreateGetM2MAnalogInputsParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v4")
        };
    }
    private IAnalogInputsResponseParser CreateGetM2MAnalogInputsParser(AnalogInputType inputType)
    {
        return inputType switch
        {
            AnalogInputType.VirtualAnalogInput => new IPX800v4GetVirtualAnalogInputsM2MResponseParser(),
            AnalogInputType.AnalogInput => new IPX800v4GetAnalogInputsM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v4")
        };
    }
    private IAnalogInputsResponseParser CreateGetHttpAnalogInputsParser(AnalogInputType inputType)
    {
        return inputType switch
        {
            AnalogInputType.VirtualAnalogInput => new IPX800v4GetVirtualAnalogInputsHttpResponseParser(),
            AnalogInputType.AnalogInput => new IPX800v4GetAnalogInputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v4")
        };
    }

    public IGetOutputResponseParser CreateGetOutputParser(IPX800Protocol protocol, OutputType outputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpOutputParser(outputType),
            IPX800Protocol.M2M => CreateGetM2MOutputParser(outputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v4")
        };
    }
    private IGetOutputResponseParser CreateGetHttpOutputParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800v4GetOutputHttpResponseParser(),
            OutputType.VirtualOutput => new IPX800v4GetVirtualOutputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v4")
        };
    }
    private IGetOutputResponseParser CreateGetM2MOutputParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800v4GetOutputM2MResponseParser(),
            OutputType.VirtualOutput => new IPX800v4GetVirtualOutputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v4")
        };
    }

    public IGetOutputsResponseParser CreateGetOutputsParser(IPX800Protocol protocol, OutputType outputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpOutputsParser(outputType),
            IPX800Protocol.M2M => CreateGetM2MOutputsParser(outputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v4")
        };
    }
    private IGetOutputsResponseParser CreateGetHttpOutputsParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800v4GetOutputsHttpResponseParser(),
            OutputType.VirtualOutput => new IPX800v4GetVirtualOutputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v4")
        };
    }
    private IGetOutputsResponseParser CreateGetM2MOutputsParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800v4GetOutputsM2MResponseParser(),
            OutputType.VirtualOutput => new IPX800v4GetVirtualOutputsM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v4")
        };
    }

    public ISetOutputResponseParser CreateSetOutputParser(IPX800Protocol protocol)
    {
        return protocol switch
        {
            IPX800Protocol.Http => new IPX800v4SetOutputHttpResponseParser(),
            IPX800Protocol.M2M => new IPX800v4SetOutputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v4")
        };
    }
}