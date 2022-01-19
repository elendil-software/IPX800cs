using IPX800cs.IO;

namespace IPX800cs.Commands.Builders;

public interface IGetAnalogInputCommandBuilder
{
    Command BuildCommandString(AnalogInput analogInput);
}