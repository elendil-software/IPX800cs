using System.Text;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4.M2M;

internal class IPX800V4SetVirtualOutputM2MCommandBuilder : ISetOutputCommandBuilder
{
    public Command BuildCommandString(Output output)
    {
        var command = new StringBuilder();

        switch (output.State)
        {
            case OutputState.Active:
                command = new StringBuilder(IPX800V4CommandStrings.SetVirtualOutputActive);
                break;

            case OutputState.Inactive:
                command = new StringBuilder(IPX800V4CommandStrings.SetVirtualOutputInactive);
                break;
        }

        command.Append(output.Number.ToString("D2"));

        return Command.CreateM2M(command.ToString());
    }
}