using System.Text;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4.Http
{
    internal class IPX800v4SetVirtualOutputHttpCommandBuilder : ISetOutputCommandBuilder
    {
        public string BuildCommandString(Output output)
        {
            var command = new StringBuilder(IPX800v4CommandStrings.HttpBaseRequest);

            switch (output.State)
            {
                case OutputState.Active:
                    command.Append(IPX800v4CommandStrings.SetVirtualOutputActive);
                    break;

                case OutputState.Inactive:
                    command.Append(IPX800v4CommandStrings.SetVirtualOutputInactive);
                    break;
            }

            command.Append(output.Number.ToString("D2"));

            return command.ToString();
        }
    }
}