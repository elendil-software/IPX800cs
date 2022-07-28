using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v3.M2M;

internal class IPX800V3GetAnalogInputM2MCommandBuilder : IGetAnalogInputCommandBuilder
{
    public Command BuildCommandString(AnalogInput analogInput)
    {
        return Command.CreateM2M($"{IPX800V3M2MCommandStrings.GetAnalogInput}{analogInput.Number}");
    }
}