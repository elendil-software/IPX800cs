using IPX800cs.IO;
#pragma warning disable CS1591

namespace IPX800cs.Commands.Builders;

public interface IGetOutputCommandBuilder
{
    Command BuildCommandString(Output output);
}