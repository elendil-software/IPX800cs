namespace IPX800cs.Commands.Builders.v3.Http;

internal class IPX800v3GetOutputsHttpCommandBuilder : IGetOutputsCommandBuilder
{
    public string BuildCommandString()
    {
        return $"{IPX800v3HttpCommandStrings.HttpJsonBaseRequest}{IPX800v3HttpCommandStrings.GetOutputs}";
    }
}