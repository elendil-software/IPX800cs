using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2.Http;

internal class IPX800v2GetInputHttpCommandBuilder : IGetInputCommandBuilder
{
    public string BuildCommandString(Input input)
    {
        return IPX800v2HttpCommandStrings.GetDigitalInput;
    }
}