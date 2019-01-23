using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v2.M2M
{
    public class Ipx800V2SetOutputOutputM2MCommandBuilder : ISetOutputCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
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