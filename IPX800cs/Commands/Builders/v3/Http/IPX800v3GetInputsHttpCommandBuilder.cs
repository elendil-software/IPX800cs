namespace IPX800cs.Commands.Builders.v3.Http;

internal class IPX800v3GetInputsHttpCommandBuilder : IGetInputsCommandBuilder
{
    public string BuildCommandString()
    {
        return $"{IPX800v3HttpCommandStrings.HttpJsonBaseRequest}{IPX800v3HttpCommandStrings.GetDigitalInputs}";
    }
}