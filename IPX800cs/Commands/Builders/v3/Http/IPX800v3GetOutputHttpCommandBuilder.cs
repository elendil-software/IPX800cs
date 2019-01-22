using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v3.Http
{
    public class IPX800v3GetOutputHttpCommandBuilder : IGetOutCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            return IPX800v3HttpCommandStrings.GetOutput;
        }
    }
}