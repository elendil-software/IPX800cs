using IPX800cs.Commands.Builders.v3.Http;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v3;

public class IPX800V3HttpCommandFactory : ICommandFactory
{
    public Command CreateGetInputCommand(Input input)
    {
        return input.Type switch
        {
            InputType.DigitalInput => new IPX800V3GetInputHttpCommandBuilder().BuildCommandString(input),
            _ => throw new IPX800NotSupportedCommandException($"Get analogInput of type '{input.Type}' is not supported by IPX800 v3")
        };
    }

    public Command CreateGetInputsCommand(InputType inputType)
    {
        if (inputType != InputType.DigitalInput)
        {
            throw new IPX800NotSupportedCommandException($"Get inputs of type '{inputType}' is not supported by IPX800 v3");
        }
            
        return new IPX800V3GetInputsHttpCommandBuilder().BuildCommandString();
    }

    public Command CreateGetAnalogInputCommand(AnalogInput analogInput)
    {
        return analogInput.Type switch
        {
            AnalogInputType.AnalogInput => new IPX800V3GetAnalogInputHttpCommandBuilder().BuildCommandString(analogInput),
            _ => throw new IPX800NotSupportedCommandException($"Get analog input of type '{analogInput.Type}' is not supported by IPX800 v3")
        };
    }

    public Command CreateGetAnalogInputsCommand(AnalogInputType analogInputType)
    {
        return analogInputType switch
        {
            AnalogInputType.AnalogInput => new IPX800V3GetAnalogInputsHttpCommandBuilder().BuildCommandString(),
            _ => throw new IPX800NotSupportedCommandException($"Get analog inputs of type '{analogInputType}' is not supported by IPX800 v3")
        };
    }

    public Command CreateGetOutputCommand(Output output)
    {
        if (output.Type != OutputType.Output && output.Type != OutputType.DelayedOutput)
        {
            throw new IPX800NotSupportedCommandException($"Get output of type '{output.Type}' is not supported by IPX800 v3");
        }
            
        return new IPX800V3GetOutputHttpCommandBuilder().BuildCommandString(output);
    }

    public Command CreateGetOutputsCommand(OutputType outputType)
    {
        if (outputType != OutputType.Output && outputType != OutputType.DelayedOutput)
        {
            throw new IPX800NotSupportedCommandException($"Get outputs of type '{outputType}' is not supported by IPX800 v3");
        }
            
        return new IPX800V3GetOutputsHttpCommandBuilder().BuildCommandString();
    }

    public Command CreateSetOutputCommand(Output output)
    {
        if (output.Type is OutputType.Output or OutputType.DelayedOutput)
        {
            return new IPX800V3SetOutputHttpCommandBuilder().BuildCommandString(output);
        }
            
        throw new IPX800NotSupportedCommandException($"Set output of type '{output.Type}' is not supported by IPX800 v3");
    }
}