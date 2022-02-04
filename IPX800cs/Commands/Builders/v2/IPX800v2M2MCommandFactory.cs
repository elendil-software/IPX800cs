using IPX800cs.Commands.Builders.v2.M2M;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2;

public class IPX800v2M2MCommandFactory : ICommandFactory
{
    public Command CreateGetInputCommand(Input input)
    {
        return input.Type switch
        {
            InputType.DigitalInput => new IPX800V2GetInputM2MCommandBuilder().BuildCommandString(input),
            _ => throw new IPX800NotSupportedCommandException($"Get analogInput of type '{input.Type}' is not supported by IPX800 v2")
        };
    }

    public Command CreateGetInputsCommand(InputType inputType)
    {
        throw new IPX800NotSupportedCommandException($"Get Inputs of type '{inputType}' is not supported by IPX800 v2, use CreateGetInputCommand for each input");
    }

    public Command CreateGetAnalogInputCommand(AnalogInput analogInput)
    {
        return analogInput.Type switch
        {
            AnalogInputType.AnalogInput => new IPX800V2GetAnalogInputM2MCommandBuilder().BuildCommandString(analogInput),
            _ => throw new IPX800NotSupportedCommandException($"Get analog input of type '{analogInput.Type}' is not supported by IPX800 v2")
        };
    }

    public Command CreateGetAnalogInputsCommand(AnalogInputType analogInputType)
    {
        throw new IPX800NotSupportedCommandException($"Get Analog inputs of type '{analogInputType}' is not supported by IPX800 v2, use CreateGetAnalogInputCommand for each input");
    }

    public Command CreateGetOutputCommand(Output output)
    {
        if (output.Type is OutputType.Output or OutputType.DelayedOutput)
        {
            return new IPX800V2GetOutputM2MCommandBuilder().BuildCommandString(output);
        }

        throw new IPX800NotSupportedCommandException($"Get output of type '{output.Type}' is not supported by IPX800 v2");
    }

    public Command CreateGetOutputsCommand(OutputType outputType)
    {
        throw new IPX800NotSupportedCommandException($"Get Outputs of type '{outputType}' is not supported by IPX800 v2, use CreateGetOutput Command for each output");
    }

    public Command CreateSetOutputCommand(Output output)
    {
        if (output.Type is OutputType.Output or OutputType.DelayedOutput)
        {
            return new IPX800V2SetOutputM2MCommandBuilder().BuildCommandString(output);
        }

        throw new IPX800NotSupportedCommandException($"Set output of type '{output.Type}' is not supported by IPX800 v2");
    }
}