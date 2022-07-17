using IPX800cs.Exceptions;
using IPX800cs.IO;
using IPX800cs.Version;

namespace IPX800cs.Commands.Builders.v5;

internal class IPX800V5HttpCommandFactory : IIPX800V5CommandFactory
{
    public Command CreateGetInputCommand(Input input)
    {
        switch (input.Type)
        {
            case InputType.DigitalInput:
            case InputType.VirtualDigitalInput:
            case InputType.OptoInput:
                return Command.CreateGet($"{IPX800V5CommandStrings.GetIO}/{input.Number}");
            default:
                throw input.Type.ThrowNotSupportedException(IPX800Version.V5);
        }
    }

    public Command CreateGetInputsCommand(InputType inputType)
    {
        switch (inputType)
        {
            case InputType.DigitalInput:
            case InputType.VirtualDigitalInput:
            case InputType.OptoInput:
                return Command.CreateGet(IPX800V5CommandStrings.GetIO);
            default:
                throw inputType.ThrowNotSupportedException(IPX800Version.V5);
        }
    }

    public Command CreateGetAnalogInputCommand(AnalogInput analogInput)
    {
        return analogInput.Type switch
        {
            AnalogInputType.AnalogInput => Command.CreateGet($"{IPX800V5CommandStrings.GetAna}/{analogInput.Number}"),
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
        switch (output.Type)
        {
            case OutputType.Output:
            case OutputType.VirtualOutput:
            case OutputType.OpenCollectorOutput:
                return Command.CreateGet($"{IPX800V5CommandStrings.GetIO}/{output.Number}");
            case OutputType.DelayedOutput:
            case OutputType.DelayedOpenCollectorOutput:
                return Command.CreateGet($"{IPX800V5CommandStrings.GetIO}");
            default:
                throw output.Type.ThrowNotSupportedException(IPX800Version.V5);
        }
    }

    public Command CreateGetOutputsCommand(OutputType outputType)
    {
        switch (outputType)
        {
            case OutputType.Output:
            case OutputType.VirtualOutput:
            case OutputType.DelayedOutput:
            case OutputType.OpenCollectorOutput:
            case OutputType.DelayedOpenCollectorOutput:
                return Command.CreateGet(IPX800V5CommandStrings.GetIO);
            default:
                throw outputType.ThrowNotSupportedException(IPX800Version.V5);
        }
    }

    public Command CreateSetOutputCommand(Output output)
    {
        switch (output.Type)
        {
            case OutputType.Output:
            case OutputType.VirtualOutput:
            case OutputType.DelayedOutput:
            case OutputType.OpenCollectorOutput:
            case OutputType.DelayedOpenCollectorOutput:
                return Command.CreatePut($"{IPX800V5CommandStrings.GetIO}/{output.Number}", $"{{\"on\": {(output.State == OutputState.Active ? "true" : "false")}}}");
            default:
                throw output.Type.ThrowNotSupportedException(IPX800Version.V5);
        }
    }

    public Command CreateGetTimersCommand()
    {
        return Command.CreateGet(IPX800V5CommandStrings.Timers);
    }
}