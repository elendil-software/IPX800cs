namespace IPX800cs.Commands.Builders.v3.Legacy.Http
{
    internal class IPX800v3LegacyGetVersionHttpCommandBuilder : IGetVersionCommandBuilder
    {
        public string BuildCommandString()
        {
            return IPX800v3LegacyHttpCommandStrings.GetVersion;
        }
    }
}