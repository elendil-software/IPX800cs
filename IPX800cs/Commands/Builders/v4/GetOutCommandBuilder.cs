using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4
{
    public class GetOutCommandBuilder : IGetOutCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            return "Get=R";
        }
    }
}
