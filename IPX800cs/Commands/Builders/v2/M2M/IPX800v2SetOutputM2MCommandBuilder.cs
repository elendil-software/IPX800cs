using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2.M2M;

internal class IPX800V2SetOutputM2MCommandBuilder : ISetOutputCommandBuilder
{
    public Command BuildCommandString(Output output)
    {
        if (output.State == OutputState.Inactive)
        {
            return Command.CreateM2M($"{IPX800v2M2MCommandStrings.SetOutput}{output.Number}{(int) output.State}");
        }
        else
        {
            if (output.Type == OutputType.DelayedOutput)
            {
                return
                    Command.CreateM2M($"{IPX800v2M2MCommandStrings.SetOutput}{output.Number}{IPX800v2M2MCommandStrings.SetOutputDelayedSuffix}");
            }
            else
            {
                return Command.CreateM2M($"{IPX800v2M2MCommandStrings.SetOutput}{output.Number}{(int) output.State}");
            }
        }
    }
}