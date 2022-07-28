using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4.M2M;

internal class IPX800V4GetOutputM2MCommandBuilder : IGetOutputCommandBuilder
{
    public Command BuildCommandString(Output output)
    {
        return Command.CreateM2M(IPX800V4CommandStrings.GetOutput);
    }
}