using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v2.Http
{
    public class IPX800v2GetOutputHttpCommandBuilder : IGetOutputCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            return IPX800v2HttpCommandStrings.GetOutput;
        }
    }
}