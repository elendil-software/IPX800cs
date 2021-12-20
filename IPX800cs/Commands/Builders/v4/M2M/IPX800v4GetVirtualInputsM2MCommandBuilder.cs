namespace IPX800cs.Commands.Builders.v4.M2M;

internal class IPX800v4GetVirtualInputsM2MCommandBuilder : IGetInputsCommandBuilder
{
    public string BuildCommandString()
    {
        return IPX800v4CommandStrings.GetVirtualInput;
    }
}