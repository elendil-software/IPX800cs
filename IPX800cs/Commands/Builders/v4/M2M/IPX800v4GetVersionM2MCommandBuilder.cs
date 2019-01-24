using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4.M2M
{
    public class IPX800v4GetVersionM2MCommandBuilder : IGetVersionCommandBuilder
    {
        public string BuildCommandString(Output output)
        {
            return IPX800v4CommandStrings.GetVersion;
        }
    }
}