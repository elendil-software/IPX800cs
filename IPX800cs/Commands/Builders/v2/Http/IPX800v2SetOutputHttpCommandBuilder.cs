using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2.Http;

internal class IPX800v2SetOutputHttpCommandBuilder : ISetOutputCommandBuilder
{
    public Command BuildCommandString(Output output)
    {
        if (output.State == OutputState.Inactive)
        {
            return Command.CreateGet($"{IPX800V2HttpCommandStrings.SetOutput}{output.Number}={(int)output.State}");
        }
        else
        {
            if (output.Type == OutputType.DelayedOutput)
            {
                return Command.CreateGet($"{IPX800V2HttpCommandStrings.SetOutputDelayed}{output.Number}=1");
            }
            else
            {
                return Command.CreateGet($"{IPX800V2HttpCommandStrings.SetOutput}{output.Number}={(int) output.State}");
            }
        }
    }
}