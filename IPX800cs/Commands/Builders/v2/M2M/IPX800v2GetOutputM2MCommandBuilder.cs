using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v2.M2M
{
    public class IPX800v2GetOutputM2MCommandBuilder : IGetOutputCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            return $"{IPX800v2M2MCommandStrings.GetOutput}{output.Number}";
        }
    }
}
