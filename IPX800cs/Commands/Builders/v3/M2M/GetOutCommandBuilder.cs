using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v3.M2M
{
    public class GetOutCommandBuilder : IGetOutCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            return $"{IPX800v3M2MCommandStrings.GetOutput}{output.Number}";
        }
    }
}
