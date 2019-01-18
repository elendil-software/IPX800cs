using software.elendil.IPX800.Commands.Builders.v4.Http;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4
{
    public class GetVirtualInHttpCommandBuilder : HttpCommandBuilderBase, IGetInCommandBuilder
    {
        public string BuildCommandString(IPX800Input input)
        {
            return $"{baseRequest}{IPX800v4CommandStrings.GetVirtualInput}";
        }
    }
}