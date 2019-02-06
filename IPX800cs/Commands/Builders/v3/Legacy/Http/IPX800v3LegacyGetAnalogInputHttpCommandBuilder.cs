using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v3.Legacy.Http
{
    internal class IPX800v3LegacyGetAnalogInputHttpCommandBuilder : IGetInputCommandBuilder
    {
        public string BuildCommandString(Input input)
        {
            return IPX800v3LegacyHttpCommandStrings.GetAnalogInput;
        }
    }
}