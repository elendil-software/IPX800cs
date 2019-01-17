using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders
{
    public interface IGetOutCommandBuilder
    {
        string BuildCommandString(IPX800Output output);
    }
}