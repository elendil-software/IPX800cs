using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v3.Http;
using IPX800cs.Parsers.v3.M2M;

namespace IPX800cs.Parsers.v3;

internal class IPX800V3ResponseParserFactory : IResponseParserFactory
{
    public IAnalogInputResponseParser GetAnalogInputParser(IPX800Protocol protocol, InputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => GetHttpAnalogInputParser(inputType),
            IPX800Protocol.M2M => GetM2MAnalogInputParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v3")
        };
    }
    private IAnalogInputResponseParser GetHttpAnalogInputParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.AnalogInput => new IPX800v3GetAnalogInputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v3")
        };
    }
    private IAnalogInputResponseParser GetM2MAnalogInputParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.AnalogInput => new IPX800v3GetAnalogInputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v3")
        };
    }

    public IInputResponseParser GetInputParser(IPX800Protocol protocol, InputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => GetHttpInputParser(inputType),
            IPX800Protocol.M2M => GetM2MInputParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v3")
        };
    }
    private IInputResponseParser GetHttpInputParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => new IPX800v3GetInputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v3")
        };
    }
    private IInputResponseParser GetM2MInputParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => new IPX800v3GetInputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v3")
        };
    }

    public IInputsResponseParser GetInputsParser(IPX800Protocol protocol, InputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => GetHttpInputsParser(inputType),
            IPX800Protocol.M2M => GetM2MInputsParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v3")
        };
    }
    private IInputsResponseParser GetM2MInputsParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => new IPX800v3GetInputsM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v3")
        };
    }
    private IInputsResponseParser GetHttpInputsParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => new IPX800v3GetInputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v3")
        };
    }
        
    public IAnalogInputsResponseParser GetAnalogInputsParser(IPX800Protocol protocol, InputType inputType)
    {
        return protocol switch
        {
            //TODO to be implemented
            //IPX800Protocol.Http => GetHttpAnalogInputsParser(inputType),
            //IPX800Protocol.M2M => GetM2MAnalogInputsParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v3")
        };
    }
    private IAnalogInputsResponseParser GetM2MAnalogInputsParser(InputType inputType)
    {
        return inputType switch
        {
            //TODO to be implemented
            //InputType.VirtualAnalogInput => new IPX800v3GetVirtualAnalogInputsM2MResponseParser(),
            //InputType.AnalogInput => new IPX800v3GetAnalogInputsM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v3")
        };
    }
    private IAnalogInputsResponseParser GetHttpAnalogInputsParser(InputType inputType)
    {
        return inputType switch
        {
            //TODO to be implemented
            //InputType.VirtualAnalogInput => new IPX800v3GetVirtualAnalogInputsHttpResponseParser(),
            //InputType.AnalogInput => new IPX800v3GetAnalogInputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v3")
        };
    }

    public IGetOutputResponseParser GetOutputParser(IPX800Protocol protocol, OutputType outputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => GetHttpOutputParser(outputType),
            IPX800Protocol.M2M => GetM2MOutputParser(outputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v3")
        };
    }
    private IGetOutputResponseParser GetHttpOutputParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800v3GetOutputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v3")
        };
    }
    private IGetOutputResponseParser GetM2MOutputParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800v3GetOutputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v3")
        };
    }

    public IGetOutputsResponseParser GetOutputsParser(IPX800Protocol protocol, OutputType outputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => GetHttpOutputsParser(outputType),
            IPX800Protocol.M2M => GetM2MOutputsParser(outputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v3")
        };
    }
    private IGetOutputsResponseParser GetHttpOutputsParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800v3GetOutputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v3")
        };
    }
    private IGetOutputsResponseParser GetM2MOutputsParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800v3GetOutputsM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v3")
        };
    }

    public ISetOutputResponseParser GetSetOutputParser(IPX800Protocol protocol)
    {
        return protocol switch
        {
            IPX800Protocol.Http => new IPX800v3SetOutputHttpResponseParser(),
            IPX800Protocol.M2M => new IPX800v3SetOutputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v3")
        };
    }
}