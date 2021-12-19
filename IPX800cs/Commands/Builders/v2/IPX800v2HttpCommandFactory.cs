using IPX800cs.Commands.Builders.v2.Http;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2;

public class IPX800v2HttpCommandFactory : ICommandFactory
{
    public string CreateGetInputCommand(Input input)
    {
        return input.Type switch
        {
            InputType.AnalogInput => new IPX800v2GetAnalogInputHttpCommandBuilder().BuildCommandString(input),
            InputType.DigitalInput => new IPX800v2GetInputHttpCommandBuilder().BuildCommandString(input),
            _ => throw new IPX800NotSupportedCommandException($"Get input of type '{input.Type}' is not supported by IPX800 v2")
        };
    }

    public string CreateGetInputsCommand(InputType input)
    {
        throw new IPX800NotSupportedCommandException("Get inputs is not supported by IPX800 v2");
    }

    public string CreateGetOutputCommand(Output output)
    {
        if (output.Type == OutputType.Output)
        {
            return new IPX800v2GetOutputHttpCommandBuilder().BuildCommandString(output);
        }

        throw new IPX800NotSupportedCommandException($"Get output of type '{output.Type}' is not supported by IPX800 v2");
    }

    public string CreateGetOutputsCommand(OutputType outputType)
    {
        throw new IPX800NotSupportedCommandException("Get outputs is not supported by IPX800 v2");
    }

    public string CreateSetOutputCommand(Output output)
    {
        if (output.Type == OutputType.Output)
        {
            return new IPX800v2SetOutputHttpCommandBuilder().BuildCommandString(output);
        }

        throw new IPX800NotSupportedCommandException($"Set output of type '{output.Type}' is not supported by IPX800 v2");
    }
}