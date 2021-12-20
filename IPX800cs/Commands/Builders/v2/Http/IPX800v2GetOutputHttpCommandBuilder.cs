using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2.Http;

internal class IPX800v2GetOutputHttpCommandBuilder : IGetOutputCommandBuilder
{
    public string BuildCommandString(Output output)
    {
        return IPX800v2HttpCommandStrings.GetOutput;
    }
}