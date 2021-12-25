using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2.M2M;

internal class IPX800v2GetAnalogInputM2MCommandBuilder : IGetAnalogInputCommandBuilder
{
    public string BuildCommandString(AnalogInput analogInput)
    {
        return $"{IPX800v2M2MCommandStrings.GetAnalogInput}{analogInput.Number}";
    }
}