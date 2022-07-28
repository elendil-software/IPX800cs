namespace IPX800cs.Commands.Builders.v4.M2M;

internal class IPX800V4GetAnalogInputsM2MCommandBuilder : IGetInputsCommandBuilder
{
    public Command BuildCommandString()
    {
        return Command.CreateM2M(IPX800V4CommandStrings.GetAnalogInput);
    }
}