namespace software.elendil.IPX800.Commands.Builders.v2.Http
{
    internal class IPX800v2GetVersionHttpCommandBuilder : IGetVersionCommandBuilder
    {
        public string BuildCommandString()
        {
            return IPX800v2HttpCommandStrings.GetVersion;
        }
    }
}