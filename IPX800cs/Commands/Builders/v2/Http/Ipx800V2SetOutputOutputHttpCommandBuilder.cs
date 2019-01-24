using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v2.Http
{
    public class IPX800v2SetOutputOutputHttpCommandBuilder : ISetOutputCommandBuilder
    {
        public string BuildCommandString(Output output)
        {
            if (output.State == OutputState.Inactive)
            {
                return $"{IPX800v2HttpCommandStrings.SetOutput}{output.Number}={(int)output.State}";
            }
            else
            {
                if (output.IsDelayed)
                {
                    return $"{IPX800v2HttpCommandStrings.SetOutputDelayed}{output.Number}=1";
                }
                else
                {
                    return $"{IPX800v2HttpCommandStrings.SetOutput}{output.Number}={(int) output.State}";
                }
            }
        }
    }
}