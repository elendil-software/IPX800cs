using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2.Http;

internal class IPX800V2GetInputHttpCommandBuilder : IGetInputCommandBuilder
{
    public Command BuildCommandString(Input input)
    {
        return Command.CreateGet(IPX800V2HttpCommandStrings.GetDigitalInput);
    }
}