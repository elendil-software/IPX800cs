using IPX800cs.IO;

namespace IPX800cs.Commands.Builders;

public interface IGetInputCommandBuilder
{
    Command BuildCommandString(Input input);
}