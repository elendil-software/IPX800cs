using IPX800cs.IO;

namespace IPX800cs.Commands.Builders;

public interface IGetAnalogInputCommandBuilder
{
    string BuildCommandString(AnalogInput analogInput);
}