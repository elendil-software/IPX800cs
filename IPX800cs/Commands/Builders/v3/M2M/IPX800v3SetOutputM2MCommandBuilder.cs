using System.Text;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v3.M2M
{
    public class IPX800v3SetOutputM2MCommandBuilder : ISetCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            var command = new StringBuilder($"{IPX800v3M2MCommandStrings.SetOutput}{output.Number:D2}{(int) output.State}");

            if (output.IsDelayed && output.State == OutputState.Active)
            {
                command.Append(IPX800v3M2MCommandStrings.SetOutputDelayedSuffix);
            }

            return command.ToString();
        }
    }
}