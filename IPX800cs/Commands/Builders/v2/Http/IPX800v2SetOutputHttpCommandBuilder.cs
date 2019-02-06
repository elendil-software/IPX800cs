using IPX800cs.IO;

namespace IPX800cs.Commands.Builders.v2.Http
{
    internal class IPX800v2SetOutputHttpCommandBuilder : ISetOutputCommandBuilder
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