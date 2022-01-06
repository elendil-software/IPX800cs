using IPX800cs.Commands.Builders.v3.Http;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v3;

public class IPX800v3HttpCommandFactory : ICommandFactory
{
    public string CreateGetInputCommand(Input input)
    {
        return input.Type switch
        {
            InputType.DigitalInput => new IPX800v3GetInputHttpCommandBuilder().BuildCommandString(input),
            _ => throw new IPX800NotSupportedCommandException($"Get analogInput of type '{input.Type}' is not supported by IPX800 v3")
        };
    }

    public string CreateGetInputsCommand(InputType inputType)
    {
        if (inputType != InputType.DigitalInput)
        {
            throw new IPX800NotSupportedCommandException($"Get inputs of type '{inputType}' is not supported by IPX800 v3");
        }
            
        return new IPX800v3GetInputsHttpCommandBuilder().BuildCommandString();
    }

    public string CreateGetAnalogInputCommand(AnalogInput analogInput)
    {
        return analogInput.Type switch
        {
            AnalogInputType.AnalogInput => new IPX800v3GetAnalogInputHttpCommandBuilder().BuildCommandString(analogInput),
            _ => throw new IPX800NotSupportedCommandException($"Get analog input of type '{analogInput.Type}' is not supported by IPX800 v3")
        };
    }

    public string CreateGetAnalogInputsCommand(AnalogInputType analogInputType)
    {
        return analogInputType switch
        {
            AnalogInputType.AnalogInput => new IPX800v3GetAnalogInputsHttpCommandBuilder().BuildCommandString(),
            _ => throw new IPX800NotSupportedCommandException($"Get analog inputs of type '{analogInputType}' is not supported by IPX800 v3")
        };
    }

    public string CreateGetOutputCommand(Output output)
    {
        if (output.Type != OutputType.Output)
        {
            throw new IPX800NotSupportedCommandException($"Get output of type '{output.Type}' is not supported by IPX800 v3");
        }
            
        return new IPX800v3GetOutputHttpCommandBuilder().BuildCommandString(output);
    }

    public string CreateGetOutputsCommand(OutputType outputType)
    {
        if (outputType != OutputType.Output)
        {
            throw new IPX800NotSupportedCommandException($"Get outputs of type '{outputType}' is not supported by IPX800 v3");
        }
            
        return new IPX800v3GetOutputsHttpCommandBuilder().BuildCommandString();
    }

    public string CreateSetOutputCommand(Output output)
    {
        if (output.Type == OutputType.Output)
        {
            return new IPX800v3SetOutputHttpCommandBuilder().BuildCommandString(output);
        }
            
        throw new IPX800NotSupportedCommandException($"Set output of type '{output.Type}' is not supported by IPX800 v3");
    }
}