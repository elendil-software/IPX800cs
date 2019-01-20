using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v2.M2M
{
    public class GetAnalogInputCommandBuilder : IGetInCommandBuilder
    {
        public string BuildCommandString(IPX800Input input)
        {
            return $"{IPX800v2M2MCommandStrings.GetAnalogInput}{input.Number}";
        }
    }
}
