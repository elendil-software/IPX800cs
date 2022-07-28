using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4.M2M;

internal class IPX800V4GetAnalogInputM2MCommandBuilder : IGetAnalogInputCommandBuilder
{
    public Command BuildCommandString(AnalogInput analogInput)
    {
        return Command.CreateM2M(IPX800V4CommandStrings.GetAnalogInput);
    }
}