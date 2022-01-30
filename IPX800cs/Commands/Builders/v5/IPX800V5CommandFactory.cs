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
            InputType.DigitalInput => Command.CreateGet(IPX800V5CommandStrings.GetIO),
            _ => throw input.Type.ThrowNotSupportedException(IPX800Version.V5)
        };
    }

    public Command CreateGetInputsCommand(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => Command.CreateGet(IPX800V5CommandStrings.GetIO),
            _ => throw inputType.ThrowNotSupportedException(IPX800Version.V5)
        };
    }

    public Command CreateGetAnalogInputCommand(AnalogInput analogInput)
    {
        return analogInput.Type switch
        {
            AnalogInputType.AnalogInput => Command.CreateGet(IPX800V5CommandStrings.GetAna),
            _ => throw analogInput.Type.ThrowNotSupportedException(IPX800Version.V5)
        };
    }

    public Command CreateGetAnalogInputsCommand(AnalogInputType analogInputType)
    {
        return analogInputType switch
        {
            AnalogInputType.AnalogInput => Command.CreateGet(IPX800V5CommandStrings.GetAna),
            _ => throw analogInputType.ThrowNotSupportedException(IPX800Version.V5)
        };
    }

    public Command CreateGetOutputCommand(Output output)
    {
        return output.Type switch
        {
            OutputType.Output => Command.CreateGet(IPX800V5CommandStrings.GetIO),
            _ => throw output.Type.ThrowNotSupportedException(IPX800Version.V5)
        };
    }

    public Command CreateGetOutputsCommand(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.Output => Command.CreateGet(IPX800V5CommandStrings.GetIO),
            _ => throw outputType.ThrowNotSupportedException(IPX800Version.V5)
        };
    }

    public Command CreateSetOutputCommand(Output output)
    {
        return output.Type switch
        {
            OutputType.Output => Command.CreatePut($"{IPX800V5CommandStrings.GetIO}/{output.Number}", $"{{on: {(output.State == OutputState.Active? "true":"false")}}}"),
            _ => throw output.Type.ThrowNotSupportedException(IPX800Version.V5)
        };
    }
}