using software.elendil.IPX800.IO;
using System.Text;

namespace software.elendil.IPX800.Commands.v4.M2M
{
        public class SetOutCommandBuilder
    {
        protected string BuildCommandString(int outputNumber, OutputState state)
        {
            var command = new StringBuilder();

            switch (state)
            {
                case OutputState.Active:
                    command = new StringBuilder($"SetR=");
                    break;

                case OutputState.Inactive:
                    command = new StringBuilder($"ClearR=");
                    break;
            }

            command.Append(outputNumber.ToString("D2"));

            return command.ToString();
        }
    }
}
