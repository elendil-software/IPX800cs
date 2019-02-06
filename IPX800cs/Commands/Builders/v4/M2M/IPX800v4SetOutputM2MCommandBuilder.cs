using System.Text;
using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v4.M2M
{
    internal class IPX800v4SetOutputM2MCommandBuilder : ISetOutputCommandBuilder
    {
        public string BuildCommandString(Output output)
        {
            StringBuilder command = null;

            switch (output.State)
            {
                case OutputState.Active:
                    command = new StringBuilder(IPX800v4CommandStrings.SetOutputActive);
                    break;

                case OutputState.Inactive:
                    command = new StringBuilder(IPX800v4CommandStrings.SetOutputInactive);
                    break;
            }

            command.Append(output.Number.ToString("D2"));

            return command.ToString();
        }
    }
}