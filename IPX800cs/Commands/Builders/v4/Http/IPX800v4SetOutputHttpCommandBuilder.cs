using System.Text;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4.Http
{
    internal class IPX800v4SetOutputHttpCommandBuilder : ISetOutputCommandBuilder
    {
        public string BuildCommandString(Output output)
        {
            var command = new StringBuilder(IPX800v4CommandStrings.HttpBaseRequest);

            switch (output.State)
            {
                case OutputState.Active:
                    command.Append(IPX800v4CommandStrings.SetOutputActive);
                    break;

                case OutputState.Inactive:
                    command.Append(IPX800v4CommandStrings.SetOutputInactive);
                    break;
            }

            command.Append(output.Number.ToString("D2"));

            return command.ToString();
        }
    }
}