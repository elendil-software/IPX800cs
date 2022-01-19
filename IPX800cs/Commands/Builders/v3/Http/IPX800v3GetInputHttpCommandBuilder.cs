using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v3.Http;

internal class IPX800V3GetInputHttpCommandBuilder : IGetInputCommandBuilder
{
    public Command BuildCommandString(Input input)
    {
        return Command.CreateGet($"{IPX800v3HttpCommandStrings.HttpJsonBaseRequest}{IPX800v3HttpCommandStrings.GetDigitalInput}");
    }
}