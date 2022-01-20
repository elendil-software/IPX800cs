using System;
using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Version;

namespace IPX800cs.Commands.Builders.v5;

public class IPX800V5HttpCommandFactory : ICommandFactory
{
    public Command CreateGetInputCommand(Input input)
    {
        return input.Type switch
        {
            InputType.DigitalInput => throw new NotImplementedException(),
            InputType.VirtualDigitalInput => throw new NotImplementedException(),
            _ => throw input.Type.ThrowNotSupportedException(IPX800Version.V5)
        };
    }

    public Command CreateGetInputsCommand(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => throw new NotImplementedException(),
            InputType.VirtualDigitalInput => throw new NotImplementedException(),
            _ => throw inputType.ThrowNotSupportedException(IPX800Version.V5)
        };
    }

    public Command CreateGetAnalogInputCommand(AnalogInput analogInput)
    {
        return analogInput.Type switch
        {
            AnalogInputType.AnalogInput => throw new NotImplementedException(),
            AnalogInputType.VirtualAnalogInput => throw new NotImplementedException(),
            _ => throw analogInput.Type.ThrowNotSupportedException(IPX800Version.V5)
        };
    }

    public Command CreateGetAnalogInputsCommand(AnalogInputType analogInputType)
    {
        return analogInputType switch
        {
            AnalogInputType.AnalogInput => throw new NotImplementedException(),
            AnalogInputType.VirtualAnalogInput => throw new NotImplementedException(),
            _ => throw analogInputType.ThrowNotSupportedException(IPX800Version.V5)
        };
    }

    public Command CreateGetOutputCommand(Output output)
    {
        return output.Type switch
        {
            OutputType.VirtualOutput => throw new NotImplementedException(),
            OutputType.Output => throw new NotImplementedException(),
            _ => throw output.Type.ThrowNotSupportedException(IPX800Version.V5)
        };
    }

    public Command CreateGetOutputsCommand(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.VirtualOutput => throw new NotImplementedException(),
            OutputType.Output => throw new NotImplementedException(),
            _ => throw outputType.ThrowNotSupportedException(IPX800Version.V5)
        };
    }

    public Command CreateSetOutputCommand(Output output)
    {
        return output.Type switch
        {
            OutputType.VirtualOutput => throw new NotImplementedException(),
            OutputType.Output => throw new NotImplementedException(),
            _ => throw output.Type.ThrowNotSupportedException(IPX800Version.V5)
        };
    }
}