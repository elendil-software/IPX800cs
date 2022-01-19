using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v3.Http;

internal class IPX800V3GetAnalogInputHttpCommandBuilder : IGetAnalogInputCommandBuilder
{
    public Command BuildCommandString(AnalogInput input)
    {
        return Command.CreateGet($"{IPX800v3HttpCommandStrings.HttpJsonBaseRequest}{IPX800v3HttpCommandStrings.GetAnalogInput}");
    }
}