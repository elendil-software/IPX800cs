using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4.Http;

internal class IPX800V4GetAnalogInputHttpCommandBuilder : IGetAnalogInputCommandBuilder
{
    public Command BuildCommandString(AnalogInput analogInput)
    {
        return Command.CreateGet($"{IPX800v4CommandStrings.HttpBaseRequest}{IPX800v4CommandStrings.GetAnalogInput}");
    }
}