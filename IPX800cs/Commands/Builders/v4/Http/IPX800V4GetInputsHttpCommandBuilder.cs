namespace IPX800cs.Commands.Builders.v4.Http;

internal class IPX800V4GetInputsHttpCommandBuilder : IGetInputsCommandBuilder
{
    public Command BuildCommandString()
    {
        return Command.CreateGet($"{IPX800V4CommandStrings.HttpBaseRequest}{IPX800V4CommandStrings.GetDigitalInput}");
    }
}