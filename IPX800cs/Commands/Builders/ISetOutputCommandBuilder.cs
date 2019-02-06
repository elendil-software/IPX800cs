using IPX800cs.IO;

namespace IPX800cs.Commands.Builders
{
    public interface ISetOutputCommandBuilder
    {
        string BuildCommandString(Output output);
    }
}