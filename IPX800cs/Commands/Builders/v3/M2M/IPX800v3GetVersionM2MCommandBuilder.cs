namespace IPX800cs.Commands.Builders.v3.M2M
{
    internal class IPX800v3GetVersionM2MCommandBuilder : IGetVersionCommandBuilder
    {
        public string BuildCommandString()
        {
            return IPX800v3M2MCommandStrings.GetVersion;
        }
    }
}