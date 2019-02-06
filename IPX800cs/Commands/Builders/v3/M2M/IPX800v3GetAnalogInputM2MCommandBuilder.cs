using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v3.M2M
{
    internal class IPX800v3GetAnalogInputM2MCommandBuilder : IGetInputCommandBuilder
    {
        public string BuildCommandString(Input input)
        {
            return $"{IPX800v3M2MCommandStrings.GetAnalogInput}{input.Number}";
        }
    }
}
