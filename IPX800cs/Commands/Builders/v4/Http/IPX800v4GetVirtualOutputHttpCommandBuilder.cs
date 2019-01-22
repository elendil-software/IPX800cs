using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4.Http
{
    public class IPX800v4GetVirtualOutputHttpCommandBuilder : HttpCommandBuilderBase, IGetOutCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            return $"{baseRequest}{IPX800v4CommandStrings.GetVirtualOutput}";
        }
    }
}