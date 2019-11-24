using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v3.M2M
{
    internal class IPX800v3GetOutputsM2MCommandBuilder : IGetOutputsCommandBuilder
    {
        public string BuildCommandString()
        {
            return IPX800v3M2MCommandStrings.GetOutputs;
        }
    }

    internal class IPX800v3GetOutputM2MCommandBuilder : IGetOutputCommandBuilder
    {
        public string BuildCommandString(Output output)
        {
            return $"{IPX800v3M2MCommandStrings.GetOutput}{output.Number}";
        }
    }
}
