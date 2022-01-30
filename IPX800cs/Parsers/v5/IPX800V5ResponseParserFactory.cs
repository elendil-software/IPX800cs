using System;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Version;

namespace IPX800cs.Parsers.v5;

internal class IPX800V5ResponseParserFactory : IResponseParserFactory
{
    public IGetInputResponseParser CreateGetInputParser(IPX800Protocol protocol, InputType inputType)
    {
        if (protocol == IPX800Protocol.Http)
        {
            return inputType switch
            {
                InputType.VirtualDigitalInput => throw new NotImplementedException(),
                InputType.DigitalInput => throw new NotImplementedException(),
                _ => throw inputType.ThrowNotSupportedException(IPX800Version.V5)
            };
        }

        throw protocol.ThrowNotSupportedException(IPX800Version.V5);
    }
    
    public IGetInputsResponseParser CreateGetInputsParser(IPX800Protocol protocol, InputType inputType)
    {
        if (protocol == IPX800Protocol.Http)
        {
            return inputType switch
            {
                InputType.VirtualDigitalInput => throw new NotImplementedException(),
                InputType.DigitalInput => throw new NotImplementedException(),
                _ => throw inputType.ThrowNotSupportedException(IPX800Version.V5)
            };
        }

        throw protocol.ThrowNotSupportedException(IPX800Version.V5);
    }
    
    public IGetAnalogInputResponseParser CreateGetAnalogInputParser(IPX800Protocol protocol, AnalogInputType analogInputType)
    {
        if (protocol == IPX800Protocol.Http)
        {
            return analogInputType switch
            {
                AnalogInputType.VirtualAnalogInput => throw new NotImplementedException(),
                AnalogInputType.AnalogInput => throw new NotImplementedException(),
                _ => throw analogInputType.ThrowNotSupportedException(IPX800Version.V5)
            };
        }

        throw protocol.ThrowNotSupportedException(IPX800Version.V5);
    }
    
    public IAnalogInputsResponseParser CreateGetAnalogInputsParser(IPX800Protocol protocol, AnalogInputType analogInputType)
    {
        if (protocol == IPX800Protocol.Http)
        {
            return analogInputType switch
            {
                AnalogInputType.VirtualAnalogInput => throw new NotImplementedException(),
                AnalogInputType.AnalogInput => throw new NotImplementedException(),
                _ => throw analogInputType.ThrowNotSupportedException(IPX800Version.V5)
            };
        }

        throw protocol.ThrowNotSupportedException(IPX800Version.V5);
    }

    public IGetOutputResponseParser CreateGetOutputParser(IPX800Protocol protocol, OutputType outputType)
    {
        if (protocol == IPX800Protocol.Http)
        {
            return outputType switch
            {
                OutputType.Output => throw new NotImplementedException(),
                OutputType.VirtualOutput => throw new NotImplementedException(),
                _ => throw outputType.ThrowNotSupportedException(IPX800Version.V5)
            };
        }

        throw protocol.ThrowNotSupportedException(IPX800Version.V5);
    }
    
    public IGetOutputsResponseParser CreateGetOutputsParser(IPX800Protocol protocol, OutputType outputType)
    {
        if (protocol == IPX800Protocol.Http)
        {
            return outputType switch
            {
                OutputType.Output => new IPX800V5GetOutputsResponseParser(),
                OutputType.VirtualOutput => throw new NotImplementedException(),
                _ => throw outputType.ThrowNotSupportedException(IPX800Version.V5)
            };
        }

        throw protocol.ThrowNotSupportedException(IPX800Version.V5);
    }
    
    public ISetOutputResponseParser CreateSetOutputParser(IPX800Protocol protocol)
    {
        if (protocol == IPX800Protocol.Http)
        {
            throw new NotImplementedException();
        }

        throw protocol.ThrowNotSupportedException(IPX800Version.V5);
    }
}