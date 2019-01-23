using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders
{
    public interface ISetOutputCommandBuilder
    {
        string BuildCommandString(Output output);
    }
}