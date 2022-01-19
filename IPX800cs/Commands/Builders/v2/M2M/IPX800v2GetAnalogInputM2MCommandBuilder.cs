using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2.M2M;

internal class IPX800V2GetAnalogInputM2MCommandBuilder : IGetAnalogInputCommandBuilder
{
    public Command BuildCommandString(AnalogInput analogInput)
    {
        return Command.CreateM2M($"{IPX800v2M2MCommandStrings.GetAnalogInput}{analogInput.Number}");
    }
}