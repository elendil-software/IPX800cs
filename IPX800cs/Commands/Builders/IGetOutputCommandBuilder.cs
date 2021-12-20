using IPX800cs.IO;

namespace IPX800cs.Commands.Builders;

public interface IGetOutputCommandBuilder
{
    string BuildCommandString(Output output);
}