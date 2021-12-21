using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v4.Http;
using IPX800cs.Parsers.v4.M2M;

namespace IPX800cs.Parsers.v4;

internal class IPX800V4ResponseParserFactory : IResponseParserFactory
{
    public IAnalogInputResponseParser GetAnalogInputParser(IPX800Protocol protocol, InputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => GetHttpAnalogInputParser(inputType),
            IPX800Protocol.M2M => GetM2MAnalogInputParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v4")
        };
    }
    private IAnalogInputResponseParser GetHttpAnalogInputParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.VirtualAnalogInput => new IPX800v4GetVirtualAnalogInputHttpResponseParser(),
            InputType.AnalogInput => new IPX800v4GetAnalogInputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v4")
        };
    }
    private IAnalogInputResponseParser GetM2MAnalogInputParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.VirtualAnalogInput => new IPX800v4GetVirtualAnalogInputM2MResponseParser(),
            InputType.AnalogInput => new IPX800v4GetAnalogInputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v4")
        };
    }

    public IInputResponseParser GetInputParser(IPX800Protocol protocol, InputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => GetHttpInputParser(inputType),
            IPX800Protocol.M2M => GetM2MInputParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v4")
        };
    }
    private IInputResponseParser GetHttpInputParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.VirtualDigitalInput => new IPX800v4GetVirtualInputHttpResponseParser(),
            InputType.DigitalInput => new IPX800v4GetInputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v4")
        };
    }
    private IInputResponseParser GetM2MInputParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.VirtualDigitalInput => new IPX800v4GetVirtualInputM2MResponseParser(),
            InputType.DigitalInput => new IPX800v4GetInputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v4")
        };
    }

    public IInputsResponseParser GetInputsParser(IPX800Protocol protocol, InputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => GetHttpInputsParser(inputType),
            IPX800Protocol.M2M => GetM2MInputsParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v4")
        };
    }
    private IInputsResponseParser GetM2MInputsParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.VirtualDigitalInput => new IPX800v4GetVirtualInputsM2MResponseParser(),
            InputType.DigitalInput => new IPX800v4GetInputsM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v4")
        };
    }
    private IInputsResponseParser GetHttpInputsParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.VirtualDigitalInput => new IPX800v4GetVirtualInputsHttpResponseParser(),
            InputType.DigitalInput => new IPX800v4GetInputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v4")
        };
    }
        
    public IAnalogInputsResponseParser GetAnalogInputsParser(IPX800Protocol protocol, InputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => GetHttpAnalogInputsParser(inputType),
            IPX800Protocol.M2M => GetM2MAnalogInputsParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v4")
        };
    }
    private IAnalogInputsResponseParser GetM2MAnalogInputsParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.VirtualAnalogInput => new IPX800v4GetVirtualAnalogInputsM2MResponseParser(),
            InputType.AnalogInput => new IPX800v4GetAnalogInputsM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v4")
        };
    }
    private IAnalogInputsResponseParser GetHttpAnalogInputsParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.VirtualAnalogInput => new IPX800v4GetVirtualAnalogInputsHttpResponseParser(),
            InputType.AnalogInput => new IPX800v4GetAnalogInputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v4")
        };
    }

    public IGetOutputResponseParser GetOutputParser(IPX800Protocol protocol, OutputType outputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => GetHttpOutputParser(outputType),
            IPX800Protocol.M2M => GetM2MOutputParser(outputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v4")
        };
    }
    private IGetOutputResponseParser GetHttpOutputParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800v4GetOutputHttpResponseParser(),
            OutputType.VirtualOutput => new IPX800v4GetVirtualOutputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v4")
        };
    }
    private IGetOutputResponseParser GetM2MOutputParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800v4GetOutputM2MResponseParser(),
            OutputType.VirtualOutput => new IPX800v4GetVirtualOutputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v4")
        };
    }

    public IGetOutputsResponseParser GetOutputsParser(IPX800Protocol protocol, OutputType outputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => GetHttpOutputsParser(outputType),
            IPX800Protocol.M2M => GetM2MOutputsParser(outputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v4")
        };
    }
    private IGetOutputsResponseParser GetHttpOutputsParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800v4GetOutputsHttpResponseParser(),
            OutputType.VirtualOutput => new IPX800v4GetVirtualOutputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v4")
        };
    }
    private IGetOutputsResponseParser GetM2MOutputsParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800v4GetOutputsM2MResponseParser(),
            OutputType.VirtualOutput => new IPX800v4GetVirtualOutputsM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v4")
        };
    }

    public ISetOutputResponseParser GetSetOutputParser(IPX800Protocol protocol)
    {
        return protocol switch
        {
            IPX800Protocol.Http => new IPX800v4SetOutputHttpResponseParser(),
            IPX800Protocol.M2M => new IPX800v4SetOutputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v4")
        };
    }
}