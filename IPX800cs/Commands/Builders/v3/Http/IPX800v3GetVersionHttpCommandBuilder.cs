namespace IPX800cs.Commands.Builders.v3.Http
{
    internal class IPX800v3GetVersionHttpCommandBuilder : IGetVersionCommandBuilder
    {
        public string BuildCommandString()
        {
            return IPX800v3HttpCommandStrings.GetVersion;
        }
    }
}