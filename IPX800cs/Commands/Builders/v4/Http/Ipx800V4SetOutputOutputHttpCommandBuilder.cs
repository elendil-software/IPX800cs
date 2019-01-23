using System.Text;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4.Http
{
    public class Ipx800V4SetOutputOutputHttpCommandBuilder : IPX800v4HttpCommandBuilderBase, ISetOutputCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            var command = new StringBuilder(IPX800v4HttpCommandBuilderBase.baseRequest);

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