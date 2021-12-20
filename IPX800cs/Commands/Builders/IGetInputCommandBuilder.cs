using IPX800cs.IO;

namespace IPX800cs.Commands.Builders;

public interface IGetInputCommandBuilder
{
    string BuildCommandString(Input input);
}