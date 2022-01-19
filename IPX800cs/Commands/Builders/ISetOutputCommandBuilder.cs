using IPX800cs.IO;

namespace IPX800cs.Commands.Builders;

public interface ISetOutputCommandBuilder
{
    Command BuildCommandString(Output output);
}