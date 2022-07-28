using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v3.Http;

internal class IPX800V3SetOutputHttpCommandBuilder : ISetOutputCommandBuilder
{
    public Command BuildCommandString(Output output)
    {
        if (output.State == OutputState.Inactive)
        {
            return Command.CreateGet($"{IPX800V3HttpCommandStrings.SetOutput}{output.Number}={(int)output.State}");
        }
        else
        {
            if (output.Type == OutputType.DelayedOutput)
            {
                return Command.CreateGet($"{IPX800V3HttpCommandStrings.SetOutputDelayed}={--output.Number}");
            }
            else
            {
                return Command.CreateGet($"{IPX800V3HttpCommandStrings.SetOutput}{output.Number}={(int)output.State}");
            }
        }
    }
}