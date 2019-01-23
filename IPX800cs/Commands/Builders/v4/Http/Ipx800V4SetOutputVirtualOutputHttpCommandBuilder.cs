using System.Text;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4.Http
{
    public class Ipx800V4SetOutputVirtualOutputHttpCommandBuilder : IPX800v4HttpCommandBuilderBase, ISetOutputCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            var command = new StringBuilder(baseRequest);

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