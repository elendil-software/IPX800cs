namespace IPX800cs.Commands.Builders.v3.M2M;

internal class IPX800V3GetInputsM2MCommandBuilder : IGetInputsCommandBuilder
{
    public Command BuildCommandString()
    {
        return Command.CreateM2M(IPX800V3M2MCommandStrings.GetDigitalInputs);
    }
}