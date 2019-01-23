using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v2.M2M
{
    public class IPX800v2GetInputM2MCommandBuilder : IGetInputCommandBuilder
    {
        public string BuildCommandString(IPX800Input input)
        {
            return $"{IPX800v2M2MCommandStrings.GetDigitalInput}{input.Number}";
        }
    }
}
