namespace software.elendil.IPX800.Commands.Builders.v3.M2M
{
    public class IPX800v3GetVersionM2MCommandBuilder : IGetVersionCommandBuilder
    {
        public string BuildCommandString()
        {
            return IPX800v3M2MCommandStrings.GetVersion;
        }
    }
}