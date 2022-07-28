using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Parsers.v3.Http;
using IPX800cs.Parsers.v3.M2M;

namespace IPX800cs.Parsers.v3;

internal class IPX800V3ResponseParserFactory : IResponseParserFactory
{
    public IGetInputResponseParser CreateGetInputParser(IPX800Protocol protocol, InputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpInputParser(inputType),
            IPX800Protocol.M2M => CreateGetM2MInputParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v3")
        };
    }
    private IGetInputResponseParser CreateGetHttpInputParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => new IPX800V3GetGetInputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v3")
        };
    }
    private IGetInputResponseParser CreateGetM2MInputParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => new IPX800V3GetGetInputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v3")
        };
    }

    public IGetInputsResponseParser CreateGetInputsParser(IPX800Protocol protocol, InputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpInputsParser(inputType),
            IPX800Protocol.M2M => CreateGetM2MInputsParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v3")
        };
    }
    private IGetInputsResponseParser CreateGetM2MInputsParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => new IPX800V3GetGetInputsM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v3")
        };
    }
    private IGetInputsResponseParser CreateGetHttpInputsParser(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => new IPX800V3GetGetInputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Input type '{inputType}' is not supported by IPX800 v3")
        };
    }
 
    public IGetAnalogInputResponseParser CreateGetAnalogInputParser(IPX800Protocol protocol, AnalogInputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpAnalogInputParser(inputType),
            IPX800Protocol.M2M => CreateGetM2MAnalogInputParser(inputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v3")
        };
    }
    private IGetAnalogInputResponseParser CreateGetHttpAnalogInputParser(AnalogInputType inputType)
    {
        return inputType switch
        {
            AnalogInputType.AnalogInput => new IPX800V3GetGetAnalogInputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v3")
        };
    }
    private IGetAnalogInputResponseParser CreateGetM2MAnalogInputParser(AnalogInputType inputType)
    {
        return inputType switch
        {
            AnalogInputType.AnalogInput => new IPX800V3GetGetAnalogInputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v3")
        };
    }
    
    public IAnalogInputsResponseParser CreateGetAnalogInputsParser(IPX800Protocol protocol, AnalogInputType inputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpAnalogInputsParser(inputType),
            IPX800Protocol.M2M => throw new IPX800NotSupportedCommandException("Get Analog Inputs Parser with protocol M2M is not supported by IPX800 v3, use CreateGetAnalogInputParser for each input"),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v3")
        };
    }
   
    private IAnalogInputsResponseParser CreateGetHttpAnalogInputsParser(AnalogInputType inputType)
    {
        return inputType switch
        {
            AnalogInputType.AnalogInput => new IPX800V3GetAnalogInputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Analog Input type '{inputType}' is not supported by IPX800 v3")
        };
    }

    public IGetOutputResponseParser CreateGetOutputParser(IPX800Protocol protocol, OutputType outputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpOutputParser(outputType),
            IPX800Protocol.M2M => CreateGetM2MOutputParser(outputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v3")
        };
    }
    private IGetOutputResponseParser CreateGetHttpOutputParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800V3GetOutputHttpResponseParser(),
            OutputType.DelayedOutput => new IPX800V3GetOutputHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v3")
        };
    }
    private IGetOutputResponseParser CreateGetM2MOutputParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800V3GetOutputM2MResponseParser(),
            OutputType.DelayedOutput => new IPX800V3GetOutputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v3")
        };
    }

    public IGetOutputsResponseParser CreateGetOutputsParser(IPX800Protocol protocol, OutputType outputType)
    {
        return protocol switch
        {
            IPX800Protocol.Http => CreateGetHttpOutputsParser(outputType),
            IPX800Protocol.M2M => CreateGetM2MOutputsParser(outputType),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v3")
        };
    }
    private IGetOutputsResponseParser CreateGetHttpOutputsParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800V3GetOutputsHttpResponseParser(),
            OutputType.DelayedOutput => new IPX800V3GetOutputsHttpResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v3")
        };
    }
    private IGetOutputsResponseParser CreateGetM2MOutputsParser(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => new IPX800V3GetOutputsM2MResponseParser(),
            OutputType.DelayedOutput => new IPX800V3GetOutputsM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Output type '{outputType}' is not supported by IPX800 v3")
        };
    }

    public ISetOutputResponseParser CreateSetOutputParser(IPX800Protocol protocol)
    {
        return protocol switch
        {
            IPX800Protocol.Http => new IPX800V3SetOutputHttpResponseParser(),
            IPX800Protocol.M2M => new IPX800V3SetOutputM2MResponseParser(),
            _ => throw new IPX800NotSupportedCommandException($"Protocol '{protocol}' is not supported by IPX800 v3")
        };
    }
}