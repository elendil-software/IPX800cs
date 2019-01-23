using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v3.Legacy.Http
{
    public class IPX800v3LegacyGetOutputHttpCommandBuilder : IGetOutputCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            return IPX800v3LegacyHttpCommandStrings.GetOutput;
        }
    }
}