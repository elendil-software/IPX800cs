﻿using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v3.M2M;

internal class IPX800V3GetOutputM2MCommandBuilder : IGetOutputCommandBuilder
{
    public Command BuildCommandString(Output output)
    {
        return Command.CreateM2M($"{IPX800v3M2MCommandStrings.GetOutput}{output.Number}");
    }
}