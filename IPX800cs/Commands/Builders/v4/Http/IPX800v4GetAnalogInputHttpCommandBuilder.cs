using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4.Http;

internal class IPX800v4GetAnalogInputHttpCommandBuilder : IGetInputCommandBuilder
{
    public string BuildCommandString(Input input)
    {
        return $"{IPX800v4CommandStrings.HttpBaseRequest}{IPX800v4CommandStrings.GetAnalogInput}";
    }
}