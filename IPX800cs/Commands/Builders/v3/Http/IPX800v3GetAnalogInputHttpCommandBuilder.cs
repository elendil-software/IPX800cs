using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v3.Http
{
    internal class IPX800v3GetAnalogInputHttpCommandBuilder : IGetInputCommandBuilder
    {
        public string BuildCommandString(Input input)
        {
            return IPX800v3HttpCommandStrings.GetAnalogInput;
        }
    }
}