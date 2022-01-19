using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2.M2M;

internal class IPX800V2GetOutputM2MCommandBuilder : IGetOutputCommandBuilder
{
    public Command BuildCommandString(Output output)
    {
        return Command.CreateM2M($"{IPX800v2M2MCommandStrings.GetOutput}{output.Number}");
    }
}