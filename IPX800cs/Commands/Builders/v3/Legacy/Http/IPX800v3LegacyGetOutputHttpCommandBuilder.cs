using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v3.Legacy.Http
{
    internal class IPX800v3LegacyGetOutputHttpCommandBuilder : IGetOutputCommandBuilder
    {
        public string BuildCommandString(Output output)
        {
            return IPX800v3LegacyHttpCommandStrings.GetOutput;
        }
    }
}