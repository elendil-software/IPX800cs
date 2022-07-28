using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2.M2M;

internal class IPX800V2GetInputM2MCommandBuilder : IGetInputCommandBuilder
{
    public Command BuildCommandString(Input input)
    {
        return Command.CreateM2M($"{IPX800V2M2MCommandStrings.GetDigitalInput}{input.Number}");
    }
}