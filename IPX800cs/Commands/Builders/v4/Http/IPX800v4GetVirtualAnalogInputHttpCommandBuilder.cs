using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4.Http;

internal class IPX800v4GetVirtualAnalogInputHttpCommandBuilder : IGetAnalogInputCommandBuilder
{
    public string BuildCommandString(AnalogInput analogInput)
    {
        return $"{IPX800v4CommandStrings.HttpBaseRequest}{IPX800v4CommandStrings.GetVirtualAnalogInput}";
    }
}