using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v3.Http;

internal class IPX800V3GetOutputHttpCommandBuilder : IGetOutputCommandBuilder
{
    public Command BuildCommandString(Output output)
    {
        return Command.CreateGet($"{IPX800v3HttpCommandStrings.HttpJsonBaseRequest}{IPX800v3HttpCommandStrings.GetOutput}");
    }
}