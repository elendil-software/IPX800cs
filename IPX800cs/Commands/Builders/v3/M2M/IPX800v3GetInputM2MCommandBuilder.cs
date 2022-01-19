using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v3.M2M;

internal class IPX800V3GetInputM2MCommandBuilder : IGetInputCommandBuilder
{
    public Command BuildCommandString(Input input)
    {
        return Command.CreateM2M($"{IPX800v3M2MCommandStrings.GetDigitalInput}{input.Number}");
    }
}