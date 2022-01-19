using IPX800cs.Commands.Builders.v4.M2M;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4;

public class IPX800V4M2MCommandFactory : ICommandFactory
{
    public Command CreateGetInputCommand(Input input)
    {
        return input.Type switch
        {
            InputType.DigitalInput => new IPX800V4GetInputM2MCommandBuilder().BuildCommandString(input),
            InputType.VirtualDigitalInput => new IPX800V4GetVirtualInputM2MCommandBuilder().BuildCommandString(input),
            _ => throw new IPX800NotSupportedCommandException($"Get analogInput of type '{input.Type}' is not supported by IPX800 v4")
        };
    }

    public Command CreateGetInputsCommand(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => new IPX800V4GetInputsM2MCommandBuilder().BuildCommandString(),
            InputType.VirtualDigitalInput => new IPX800V4GetVirtualInputsM2MCommandBuilder().BuildCommandString(),
            _ => throw new IPX800NotSupportedCommandException($"Get inputs of type '{inputType}' is not supported by IPX800 v4")
        };
    }

    public Command CreateGetAnalogInputCommand(AnalogInput analogInput)
    {
        return analogInput.Type switch
        {
            AnalogInputType.AnalogInput => new IPX800V4GetAnalogInputM2MCommandBuilder().BuildCommandString(analogInput),
            AnalogInputType.VirtualAnalogInput => new IPX800V4GetVirtualAnalogInputM2MCommandBuilder().BuildCommandString(analogInput),
            _ => throw new IPX800NotSupportedCommandException($"Get analog input of type '{analogInput.Type}' is not supported by IPX800 v4")
        };
    }

    public Command CreateGetAnalogInputsCommand(AnalogInputType analogInputType)
    {
        return analogInputType switch
        {
            AnalogInputType.AnalogInput => new IPX800V4GetAnalogInputsM2MCommandBuilder().BuildCommandString(),
            AnalogInputType.VirtualAnalogInput => new IPX800V4GetVirtualAnalogInputsM2MCommandBuilder().BuildCommandString(),
            _ => throw new IPX800NotSupportedCommandException($"Get analog inputs of type '{analogInputType}' is not supported by IPX800 v4")
        };
    }

    public Command CreateGetOutputCommand(Output output)
    {
        return output.Type switch
        {
            OutputType.VirtualOutput => new IPX800V4GetVirtualOutputM2MCommandBuilder().BuildCommandString(output),
            OutputType.Output => new IPX800V4GetOutputM2MCommandBuilder().BuildCommandString(output),
            _ => throw new IPX800NotSupportedCommandException($"Get output of type '{output.Type}' is not supported by IPX800 v4")
        };
    }

    public Command CreateGetOutputsCommand(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.VirtualOutput => new IPX800V4GetVirtualOutputsM2MCommandBuilder().BuildCommandString(),
            OutputType.Output => new IPX800V4GetOutputsM2MCommandBuilder().BuildCommandString(),
            _ => throw new IPX800NotSupportedCommandException($"Get outputs of type '{outputType}' is not supported by IPX800 v4")
        };
    }

    public Command CreateSetOutputCommand(Output output)
    {
        return output.Type switch
        {
            OutputType.VirtualOutput => new IPX800v4SetVirtualOutputM2MCommandBuilder().BuildCommandString(output),
            OutputType.Output => new IPX800V4SetOutputM2MCommandBuilder().BuildCommandString(output),
            _ => throw new IPX800NotSupportedCommandException($"Set output of type '{output.Type}' is not supported by IPX800 v4")
        };
    }
}