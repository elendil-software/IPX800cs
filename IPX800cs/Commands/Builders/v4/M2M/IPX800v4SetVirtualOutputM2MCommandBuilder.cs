using System.Text;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4.M2M;

internal class IPX800v4SetVirtualOutputM2MCommandBuilder : ISetOutputCommandBuilder
{
    public string BuildCommandString(Output output)
    {
        var command = new StringBuilder();

        switch (output.State)
        {
            case OutputState.Active:
                command = new StringBuilder(IPX800v4CommandStrings.SetVirtualOutputActive);
                break;

            case OutputState.Inactive:
                command = new StringBuilder(IPX800v4CommandStrings.SetVirtualOutputInactive);
                break;
        }

        command.Append(output.Number.ToString("D2"));

        return command.ToString();
    }
}