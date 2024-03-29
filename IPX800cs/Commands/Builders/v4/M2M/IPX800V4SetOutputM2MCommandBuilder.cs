﻿using System.Text;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4.M2M;

internal class IPX800V4SetOutputM2MCommandBuilder : ISetOutputCommandBuilder
{
    public Command BuildCommandString(Output output)
    {
        StringBuilder command = output.State switch
        {
            OutputState.Active => new StringBuilder(IPX800V4CommandStrings.SetOutputActive),
            OutputState.Inactive => new StringBuilder(IPX800V4CommandStrings.SetOutputInactive),
            _ => throw new IPX800InvalidContextException($"'{output.State}' is not a valid output state")
        };

        command.Append(output.Number.ToString("D2"));

        return Command.CreateM2M(command.ToString());
    }
}