using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2.Http;

internal class IPX800V2GetOutputHttpCommandBuilder : IGetOutputCommandBuilder
{
    public Command BuildCommandString(Output output)
    {
        return Command.CreateGet(IPX800V2HttpCommandStrings.GetOutput);
    }
}