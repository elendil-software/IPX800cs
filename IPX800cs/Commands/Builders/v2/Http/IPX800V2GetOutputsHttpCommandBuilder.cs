namespace IPX800cs.Commands.Builders.v2.Http;

internal class IPX800V2GetOutputsHttpCommandBuilder : IGetOutputsCommandBuilder
{
    public Command BuildCommandString()
    {
        return Command.CreateGet(IPX800V2HttpCommandStrings.GetOutput);
    }
}