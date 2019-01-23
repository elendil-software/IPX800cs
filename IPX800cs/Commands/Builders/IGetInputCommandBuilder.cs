using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders
{
    public interface IGetInputCommandBuilder
    {
        string BuildCommandString(IPX800Input input);
    }
}