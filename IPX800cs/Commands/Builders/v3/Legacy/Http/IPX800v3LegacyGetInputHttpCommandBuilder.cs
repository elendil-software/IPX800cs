using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v3.Legacy.Http
{
    internal class IPX800v3LegacyGetInputHttpCommandBuilder : IGetInputCommandBuilder
    {
        public string BuildCommandString(Input input)
        {
            return IPX800v3LegacyHttpCommandStrings.GetDigitalInput;
        }
    }
}