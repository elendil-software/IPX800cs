namespace IPX800cs.Commands.Builders.v4.M2M;

internal class IPX800V4GetInputsM2MCommandBuilder : IGetInputsCommandBuilder
{
    public Command BuildCommandString()
    {
        return Command.CreateM2M(IPX800v4CommandStrings.GetDigitalInput);
    }
}