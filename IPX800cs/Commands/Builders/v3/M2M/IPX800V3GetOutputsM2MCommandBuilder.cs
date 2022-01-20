﻿namespace IPX800cs.Commands.Builders.v3.M2M;

internal class IPX800V3GetOutputsM2MCommandBuilder : IGetOutputsCommandBuilder
{
    public Command BuildCommandString()
    {
        return Command.CreateM2M(IPX800v3M2MCommandStrings.GetOutputs);
    }
}