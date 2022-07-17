using IPX800cs.IO;
#pragma warning disable CS1591

namespace IPX800cs.Commands.Builders;

public interface ISetOutputCommandBuilder
{
    Command BuildCommandString(Output output);
}