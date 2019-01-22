using System.Text;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4.M2M
{
    public class IPX800v4SetVirtualOutputM2MCommandBuilder : ISetCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
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
}
