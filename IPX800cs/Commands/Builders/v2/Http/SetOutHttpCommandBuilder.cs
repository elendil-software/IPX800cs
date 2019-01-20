using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v2.Http
{
    public class SetOutHttpCommandBuilder : ISetCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            if (output.IsDelayed)
            {
                return $"{IPX800v2HttpCommandStrings.SetOutputDelayed}{output.Number}=1";
            }
            else
            {
                return $"{IPX800v2HttpCommandStrings.SetOutput}{output.Number}={(int)output.State}";
            }
        }
    }
}