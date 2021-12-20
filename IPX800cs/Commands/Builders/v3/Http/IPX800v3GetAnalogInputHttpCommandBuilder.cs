using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v3.Http;

internal class IPX800v3GetAnalogInputHttpCommandBuilder : IGetInputCommandBuilder
{
    public string BuildCommandString(Input input)
    {
        return $"{IPX800v3HttpCommandStrings.HttpJsonBaseRequest}{IPX800v3HttpCommandStrings.GetAnalogInput}";
    }
}