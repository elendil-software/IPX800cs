namespace IPX800cs.Commands.Builders.v3.Http;

internal class IPX800V3GetInputsHttpCommandBuilder : IGetInputsCommandBuilder
{
    public Command BuildCommandString()
    {
        return Command.CreateGet($"{IPX800v3HttpCommandStrings.HttpJsonBaseRequest}{IPX800v3HttpCommandStrings.GetDigitalInputs}");
    }
}