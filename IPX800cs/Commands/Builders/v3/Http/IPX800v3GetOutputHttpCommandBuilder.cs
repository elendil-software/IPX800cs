using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v3.Http;

internal class IPX800v3GetOutputHttpCommandBuilder : IGetOutputCommandBuilder
{
    public string BuildCommandString(Output output)
    {
        return $"{IPX800v3HttpCommandStrings.HttpJsonBaseRequest}{IPX800v3HttpCommandStrings.GetOutput}";
    }
}