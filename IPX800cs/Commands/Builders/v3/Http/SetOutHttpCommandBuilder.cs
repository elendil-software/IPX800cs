using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v3.Http
{
    public class SetOutHttpCommandBuilder : ISetCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            if (output.IsDelayed)
            {
                return $"{IPX800v3HttpCommandStrings.SetOutputDelayed}={--output.Number}";
            }
            else
            {
                return $"{IPX800v3HttpCommandStrings.SetOutput}{output.Number}={(int)output.State}";
            }
        }
    }
}