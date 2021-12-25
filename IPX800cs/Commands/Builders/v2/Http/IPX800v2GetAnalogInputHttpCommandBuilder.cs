using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2.Http;

internal class IPX800v2GetAnalogInputHttpCommandBuilder : IGetAnalogInputCommandBuilder
{
    public string BuildCommandString(AnalogInput input)
    {
        return IPX800v2HttpCommandStrings.GetAnalogInput;
    }
}