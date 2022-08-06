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
    private static IGetInputResponseParser CreateGetHttpInputParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.VirtualDigitalInput => new IPX800V4GetVirtualGetInputHttpResponseParser(),
            InputType.DigitalInput => new IPX800V4GetGetInputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v4")
        };
    }
    private static IGetInputResponseParser CreateGetM2MInputParser(InputType inputType)
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
    private static IGetInputsResponseParser CreateGetM2MInputsParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.VirtualDigitalInput => new IPX800V4GetVirtualGetInputsM2MResponseParser(),
            InputType.DigitalInput => new IPX800V4GetGetInputsM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v4")
        };
    }
    private static IGetInputsResponseParser CreateGetHttpInputsParser(InputType inputType)
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
    private static IGetAnalogInputResponseParser CreateGetHttpAnalogInputParser(AnalogInputType inputType)
    {
        return inputType switch
        {
            AnalogInputType.VirtualAnalogInput => new IPX800V4GetVirtualGetAnalogInputHttpResponseParser(),
            AnalogInputType.AnalogInput => new IPX800V4GetGetAnalogInputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v4")
        };
    }
    private static IGetAnalogInputResponseParser CreateGetM2MAnalogInputParser(AnalogInputType inputType)
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
    private static IAnalogInputsResponseParser CreateGetM2MAnalogInputsParser(AnalogInputType inputType)
    {
        return inputType switch
        {
            AnalogInputType.VirtualAnalogInput => new IPX800V4GetVirtualAnalogInputsM2MResponseParser(),
            AnalogInputType.AnalogInput => new IPX800V4GetAnalogInputsM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v4")
        };
    }
    private static IAnalogInputsResponseParser CreateGetHttpAnalogInputsParser(AnalogInputType inputType)
    {
        return inputType switch
        {
            AnalogInputType.VirtualAnalogInput => new IPX800V4GetVirtualAnalogInputsHttpResponseParser(),
            AnalogInputType.AnalogInput => new IPX800V4GetAnalogInputsHttpResponseParser(),
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
    private static IGetOutputResponseParser CreateGetHttpOutputParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800V4GetOutputHttpResponseParser(),
            OutputType.DelayedOutput => new IPX800V4GetOutputHttpResponseParser(),
            OutputType.VirtualOutput => new IPX800V4GetVirtualOutputHttpResponseParser(),
            OutputType.DelayedVirtualOutput => new IPX800V4GetVirtualOutputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v4")
        };
    }
    private static IGetOutputResponseParser CreateGetM2MOutputParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800V4GetOutputM2MResponseParser(),
            OutputType.DelayedOutput => new IPX800V4GetOutputM2MResponseParser(),
            OutputType.VirtualOutput => new IPX800V4GetVirtualOutputM2MResponseParser(),
            OutputType.DelayedVirtualOutput => new IPX800V4GetVirtualOutputM2MResponseParser(),
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
    private static IGetOutputsResponseParser CreateGetHttpOutputsParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800V4GetOutputsHttpResponseParser(),
            OutputType.DelayedOutput => new IPX800V4GetOutputsHttpResponseParser(),
            OutputType.VirtualOutput => new IPX800V4GetVirtualOutputsHttpResponseParser(),
            OutputType.DelayedVirtualOutput => new IPX800V4GetVirtualOutputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v4")
        };
    }
    private static IGetOutputsResponseParser CreateGetM2MOutputsParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800V4GetOutputsM2MResponseParser(),
            OutputType.DelayedOutput => new IPX800V4GetOutputsM2MResponseParser(),
            OutputType.VirtualOutput => new IPX800V4GetVirtualOutputsM2MResponseParser(),
            OutputType.DelayedVirtualOutput => new IPX800V4GetVirtualOutputsM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v4")
        };
    }

    public ISetOutputResponseParser CreateSetOutputParser(IPX800Protocol protocol)
    {
        return protocol switch
        {
            IPX800Protocol.Http => new IPX800V4SetOutputHttpResponseParser(),
            IPX800Protocol.M2M => new IPX800V4SetOutputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v4")
        };
    }
}