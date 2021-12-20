namespace IPX800cs.Commands.Builders.v4.M2M;

internal class IPX800v4GetVirtualOutputsM2MCommandBuilder : IGetOutputsCommandBuilder
{
    public string BuildCommandString()
    {
        return IPX800v4CommandStrings.GetVirtualOutput;
    }
}