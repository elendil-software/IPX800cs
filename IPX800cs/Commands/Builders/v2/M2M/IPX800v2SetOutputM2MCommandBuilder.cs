using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v2.M2M
{
    public class IPX800v2SetOutputM2MCommandBuilder : ISetOutputCommandBuilder
    {
        public string BuildCommandString(Output output)
        {
            if (output.State == OutputState.Inactive)
            {
                return $"{IPX800v2M2MCommandStrings.SetOutput}{output.Number}{(int) output.State}";
            }
            else
            {
                if (output.IsDelayed)
                {
                    return
                        $"{IPX800v2M2MCommandStrings.SetOutput}{output.Number}{IPX800v2M2MCommandStrings.SetOutputDelayedSuffix}";
                }
                else
                {
                    return $"{IPX800v2M2MCommandStrings.SetOutput}{output.Number}{(int) output.State}";
                }
            }
        }
    }
}