﻿using IPX800cs.Commands.Builders.v2.M2M;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2;

public class IPX800v2M2MCommandFactory : ICommandFactory
{
    public string CreateGetInputCommand(Input input)
    {
        return input.Type switch
        {
            InputType.AnalogInput => new IPX800v2GetAnalogInputM2MCommandBuilder().BuildCommandString(input),
            InputType.DigitalInput => new IPX800v2GetInputM2MCommandBuilder().BuildCommandString(input),
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
            return new IPX800v2GetOutputM2MCommandBuilder().BuildCommandString(output);
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
            return new IPX800v2SetOutputM2MCommandBuilder().BuildCommandString(output);
        }

        throw new IPX800NotSupportedCommandException($"Set output of type '{output.Type}' is not supported by IPX800 v2");
    }
}