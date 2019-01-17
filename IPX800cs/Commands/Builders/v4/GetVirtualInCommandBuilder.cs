using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4
{
    public class GetVirtualInCommandBuilder : IGetInCommandBuilder
    {
        public string BuildCommandString(IPX800Input input)
        {
            return "Get=VI";
        }
    }
}
