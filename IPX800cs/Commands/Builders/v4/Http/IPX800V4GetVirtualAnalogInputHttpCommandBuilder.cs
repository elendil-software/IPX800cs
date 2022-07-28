using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4.Http;

internal class IPX800V4GetVirtualAnalogInputHttpCommandBuilder : IGetAnalogInputCommandBuilder
{
    public Command BuildCommandString(AnalogInput analogInput)
    {
        return Command.CreateGet($"{IPX800V4CommandStrings.HttpBaseRequest}{IPX800V4CommandStrings.GetVirtualAnalogInput}");
    }
}