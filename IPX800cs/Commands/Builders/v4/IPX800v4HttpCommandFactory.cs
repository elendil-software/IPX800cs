using IPX800cs.Commands.Builders.v4.Http;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4;

public class IPX800v4HttpCommandFactory : ICommandFactory
{
    public string CreateGetInputCommand(Input input)
    {
        return input.Type switch
        {
            InputType.AnalogInput => new IPX800v4GetAnalogInputHttpCommandBuilder().BuildCommandString(input),
            InputType.DigitalInput => new IPX800v4GetInputHttpCommandBuilder().BuildCommandString(input),
            InputType.VirtualAnalogInput => new IPX800v4GetVirtualAnalogInputHttpCommandBuilder().BuildCommandString(input),
            InputType.VirtualDigitalInput => new IPX800v4GetVirtualInputHttpCommandBuilder().BuildCommandString(input),
            _ => throw new IPX800NotSupportedCommandException($"Get input of type '{input.Type}' is not supported by IPX800 v4")
        };
    }

    public string CreateGetInputsCommand(InputType inputType)
    {
        return inputType switch
        {
            InputType.DigitalInput => new IPX800v4GetInputsHttpCommandBuilder().BuildCommandString(),
            InputType.AnalogInput => new IPX800v4GetAnalogInputsHttpCommandBuilder().BuildCommandString(),
            InputType.VirtualAnalogInput => new IPX800v4GetVirtualAnalogInputsHttpCommandBuilder().BuildCommandString(),
            InputType.VirtualDigitalInput => new IPX800v4GetVirtualInputsHttpCommandBuilder().BuildCommandString(),
            _ => throw new IPX800NotSupportedCommandException($"Get inputs of type '{inputType}' is not supported by IPX800 v4")
        };
    }

    public string CreateGetOutputCommand(Output output)
    {
        return output.Type switch
        {
            OutputType.VirtualOutput => new IPX800v4GetVirtualOutputHttpCommandBuilder().BuildCommandString(output),
            OutputType.Output => new IPX800v4GetOutputHttpCommandBuilder().BuildCommandString(output),
            _ => throw new IPX800NotSupportedCommandException($"Get output of type '{output.Type}' is not supported by IPX800 v4")
        };
    }

    public string CreateGetOutputsCommand(OutputType outputType)
    {
        return outputType switch
        {
            OutputType.VirtualOutput => new IPX800v4GetVirtualOutputsHttpCommandBuilder().BuildCommandString(),
            OutputType.Output => new IPX800v4GetOutputsHttpCommandBuilder().BuildCommandString(),
            _ => throw new IPX800NotSupportedCommandException($"Get outputs of type '{outputType}' is not supported by IPX800 v4")
        };
    }

    public string CreateSetOutputCommand(Output output)
    {
        return output.Type switch
        {
            OutputType.VirtualOutput => new IPX800v4SetVirtualOutputHttpCommandBuilder().BuildCommandString(output),
            OutputType.Output => new IPX800v4SetOutputHttpCommandBuilder().BuildCommandString(output),
            _ => throw new IPX800NotSupportedCommandException($"Set output of type '{output.Type}' is not supported by IPX800 v4")
        };
    }
}