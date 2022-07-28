using IPX800cs.Commands.Builders.v4.Http;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4;

internal class IPX800V4HttpCommandFactory : ICommandFactory
{
    public Command CreateGetInputCommand(Input input)
    {
        return input.Type switch
        {
            InputType.DigitalInput => new IPX800V4GetInputHttpCommandBuilder().BuildCommandString(input),
            InputType.VirtualDigitalInput => new IPX800V4GetVirtualInputHttpCommandBuilder().BuildCommandString(input),
            _ => throw new IPX800NotSupportedCommandException($"Get analogInput of type '{input.Type}' is not supported by IPX800 v4")
        };
    }

    public Command CreateGetInputsCommand(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => new IPX800V4GetInputsHttpCommandBuilder().BuildCommandString(),
            InputType.VirtualDigitalInput => new IPX800V4GetVirtualInputsHttpCommandBuilder().BuildCommandString(),
            _ => throw new IPX800NotSupportedCommandException($"Get inputs of type '{inputType}' is not supported by IPX800 v4")
        };
    }

    public Command CreateGetAnalogInputCommand(AnalogInput analogInput)
    {
        return analogInput.Type switch
        {
            AnalogInputType.AnalogInput => new IPX800V4GetAnalogInputHttpCommandBuilder().BuildCommandString(analogInput),
            AnalogInputType.VirtualAnalogInput => new IPX800V4GetVirtualAnalogInputHttpCommandBuilder().BuildCommandString(analogInput),
            _ => throw new IPX800NotSupportedCommandException($"Get analog input of type '{analogInput.Type}' is not supported by IPX800 v4")
        };
    }

    public Command CreateGetAnalogInputsCommand(AnalogInputType analogInputType)
    {
        return analogInputType switch
        {
            AnalogInputType.AnalogInput => new IPX800V4GetAnalogInputsHttpCommandBuilder().BuildCommandString(),
            AnalogInputType.VirtualAnalogInput => new IPX800V4GetVirtualAnalogInputsHttpCommandBuilder().BuildCommandString(),
            _ => throw new IPX800NotSupportedCommandException($"Get analog inputs of type '{analogInputType}' is not supported by IPX800 v4")
        };
    }

    public Command CreateGetOutputCommand(Output output)
    {
        return output.Type switch
        {
            OutputType.VirtualOutput => new IPX800V4GetVirtualOutputHttpCommandBuilder().BuildCommandString(output),
            OutputType.DelayedVirtualOutput => new IPX800V4GetVirtualOutputHttpCommandBuilder().BuildCommandString(output),
            OutputType.Output => new IPX800V4GetOutputHttpCommandBuilder().BuildCommandString(output),
            OutputType.DelayedOutput => new IPX800V4GetOutputHttpCommandBuilder().BuildCommandString(output),
            _ => throw new IPX800NotSupportedCommandException($"Get output of type '{output.Type}' is not supported by IPX800 v4")
        };
    }

    public Command CreateGetOutputsCommand(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.VirtualOutput => new IPX800V4GetVirtualOutputsHttpCommandBuilder().BuildCommandString(),
            OutputType.DelayedVirtualOutput => new IPX800V4GetVirtualOutputsHttpCommandBuilder().BuildCommandString(),
            OutputType.Output => new IPX800V4GetOutputsHttpCommandBuilder().BuildCommandString(),
            OutputType.DelayedOutput => new IPX800V4GetOutputsHttpCommandBuilder().BuildCommandString(),
            _ => throw new IPX800NotSupportedCommandException($"Get outputs of type '{outputType}' is not supported by IPX800 v4")
        };
    }

    public Command CreateSetOutputCommand(Output output)
    {
        return output.Type switch
        {
            OutputType.VirtualOutput => new IPX800V4SetVirtualOutputHttpCommandBuilder().BuildCommandString(output),
            OutputType.DelayedVirtualOutput => new IPX800V4SetVirtualOutputHttpCommandBuilder().BuildCommandString(output),
            OutputType.Output => new IPX800V4SetOutputHttpCommandBuilder().BuildCommandString(output),
            OutputType.DelayedOutput => new IPX800V4SetOutputHttpCommandBuilder().BuildCommandString(output),
            _ => throw new IPX800NotSupportedCommandException($"Set output of type '{output.Type}' is not supported by IPX800 v4")
        };
    }
}