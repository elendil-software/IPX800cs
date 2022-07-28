using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2.Http;

internal class IPX800V2GetAnalogInputHttpCommandBuilder : IGetAnalogInputCommandBuilder
{
    public Command BuildCommandString(AnalogInput input)
    {
        return Command.CreateGet(IPX800V2HttpCommandStrings.GetAnalogInput);
    }
}