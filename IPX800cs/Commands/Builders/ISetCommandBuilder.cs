using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders
{
    public interface ISetCommandBuilder
    {
        string BuildCommandString(IPX800Output output);
    }
}