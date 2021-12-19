using IPX800cs.Commands.Builders.v4.M2M;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4;

public class IPX800v4M2MCommandFactory : ICommandFactory
{
    public string CreateGetInputCommand(Input input)
    {
        return input.Type switch
        {
            InputType.AnalogInput => new IPX800v4GetAnalogInputM2MCommandBuilder().BuildCommandString(input),
            InputType.DigitalInput => new IPX800v4GetInputM2MCommandBuilder().BuildCommandString(input),
            InputType.VirtualAnalogInput => new IPX800v4GetVirtualAnalogInputM2MCommandBuilder().BuildCommandString(input),
            InputType.VirtualDigitalInput => new IPX800v4GetVirtualInputM2MCommandBuilder().BuildCommandString(input),
            _ => throw new IPX800NotSupportedCommandException($"Get input of type '{input.Type}' is not supported by IPX800 v4")
        };
    }

    public string CreateGetInputsCommand(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => new IPX800v4GetInputsM2MCommandBuilder().BuildCommandString(),
            InputType.AnalogInput => new IPX800v4GetAnalogInputsM2MCommandBuilder().BuildCommandString(),
            InputType.VirtualAnalogInput => new IPX800v4GetVirtualAnalogInputsM2MCommandBuilder().BuildCommandString(),
            InputType.VirtualDigitalInput => new IPX800v4GetVirtualInputsM2MCommandBuilder().BuildCommandString(),
            _ => throw new IPX800NotSupportedCommandException($"Get inputs of type '{inputType}' is not supported by IPX800 v4")
        };
    }

    public string CreateGetOutputCommand(Output output)
    {
        return output.Type switch
        {
            OutputType.VirtualOutput => new IPX800v4GetVirtualOutputM2MCommandBuilder().BuildCommandString(output),
            OutputType.Output => new IPX800v4GetOutputM2MCommandBuilder().BuildCommandString(output),
            _ => throw new IPX800NotSupportedCommandException($"Get output of type '{output.Type}' is not supported by IPX800 v4")
        };
    }

    public string CreateGetOutputsCommand(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.VirtualOutput => new IPX800v4GetVirtualOutputsM2MCommandBuilder().BuildCommandString(),
            OutputType.Output => new IPX800v4GetOutputsM2MCommandBuilder().BuildCommandString(),
            _ => throw new IPX800NotSupportedCommandException($"Get outputs of type '{outputType}' is not supported by IPX800 v4")
        };
    }

    public string CreateSetOutputCommand(Output output)
    {
        return output.Type switch
        {
            OutputType.VirtualOutput => new IPX800v4SetVirtualOutputM2MCommandBuilder().BuildCommandString(output),
            OutputType.Output => new IPX800v4SetOutputM2MCommandBuilder().BuildCommandString(output),
            _ => throw new IPX800NotSupportedCommandException($"Set output of type '{output.Type}' is not supported by IPX800 v4")
        };
    }
}