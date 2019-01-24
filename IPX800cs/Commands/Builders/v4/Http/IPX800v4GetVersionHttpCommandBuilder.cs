using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4.Http
{
    public class IPX800v4GetVersionHttpCommandBuilder : IGetVersionCommandBuilder
    {
        public string BuildCommandString(Output output)
        {
            return IPX800v4CommandStrings.GetVersion;
        }
    }
}