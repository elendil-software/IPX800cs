namespace IPX800cs.Commands.Builders.v4.Http;

internal class IPX800v4GetInputsHttpCommandBuilder : IGetInputsCommandBuilder
{
    public string BuildCommandString()
    {
        return $"{IPX800v4CommandStrings.HttpBaseRequest}{IPX800v4CommandStrings.GetDigitalInput}";
    }
}