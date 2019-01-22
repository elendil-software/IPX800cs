using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v3.Http
{
    public class IPX800v3SetOutputHttpCommandBuilder : ISetCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            if (output.State == OutputState.Inactive)
            {
                return $"{IPX800v3HttpCommandStrings.SetOutput}{output.Number}={(int)output.State}";
            }
            else
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
}