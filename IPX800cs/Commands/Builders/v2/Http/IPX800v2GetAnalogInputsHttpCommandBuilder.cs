namespace IPX800cs.Commands.Builders.v2.Http;

internal class IPX800V2GetAnalogInputsHttpCommandBuilder : IGetInputsCommandBuilder
{
    public Command BuildCommandString()
    {
        return Command.CreateGet(IPX800V2HttpCommandStrings.GetAnalogInput);
    }
}