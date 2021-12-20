using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4.Http;

internal class IPX800v4GetOutputHttpCommandBuilder : IGetOutputCommandBuilder
{
    public string BuildCommandString(Output output)
    {
        return $"{IPX800v4CommandStrings.HttpBaseRequest}{IPX800v4CommandStrings.GetOutput}";
    }
}