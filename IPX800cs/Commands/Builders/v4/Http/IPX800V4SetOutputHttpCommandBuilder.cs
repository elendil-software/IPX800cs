using System.Text;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4.Http;

internal class IPX800V4SetOutputHttpCommandBuilder : ISetOutputCommandBuilder
{
    public Command BuildCommandString(Output output)
    {
        var command = new StringBuilder(IPX800V4CommandStrings.HttpBaseRequest);

        switch (output.State)
        {
            case OutputState.Active:
                command.Append(IPX800V4CommandStrings.SetOutputActive);
                break;

            case OutputState.Inactive:
                command.Append(IPX800V4CommandStrings.SetOutputInactive);
                break;
        }

        command.Append(output.Number.ToString("D2"));

        return Command.CreateGet(command.ToString());
    }
}