using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4.M2M
{
    internal class IPX800v4GetVirtualInputM2MCommandBuilder : IGetInputCommandBuilder
    {
        public string BuildCommandString(Input input)
        {
            return IPX800v4CommandStrings.GetVirtualInput;
        }
    }
}
