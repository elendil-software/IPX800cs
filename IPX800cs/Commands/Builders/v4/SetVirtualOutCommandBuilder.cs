using System.Text;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4
{
    public class SetVirtualOutCommandBuilder : ISetCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            var command = new StringBuilder();

            switch (output.State)
            {
                case OutputState.Active:
                    command = new StringBuilder($"SetVO=");
                    break;

                case OutputState.Inactive:
                    command = new StringBuilder($"ClearVO=");
                    break;
            }

            command.Append(output.Number.ToString("D2"));

            return command.ToString();
        }
    }
}
