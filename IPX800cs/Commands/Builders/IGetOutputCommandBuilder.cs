using IPX800cs.IO;

namespace IPX800cs.Commands.Builders;

public interface IGetOutputCommandBuilder
{
    Command BuildCommandString(Output output);
}