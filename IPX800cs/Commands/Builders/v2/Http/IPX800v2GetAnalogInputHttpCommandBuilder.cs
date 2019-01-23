using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v2.Http
{
    public class IPX800v2GetAnalogInputHttpCommandBuilder : IGetInputCommandBuilder
    {
        public string BuildCommandString(IPX800Input input)
        {
            return IPX800v2HttpCommandStrings.GetAnalogInput;
        }
    }
}