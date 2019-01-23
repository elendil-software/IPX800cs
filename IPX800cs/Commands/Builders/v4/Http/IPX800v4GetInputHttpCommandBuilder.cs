using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4.Http
{
    public class IPX800v4GetInputHttpCommandBuilder : IGetInputCommandBuilder
    {
        public string BuildCommandString(IPX800Input input)
        {
            return $"{IPX800v4CommandStrings.HttpBaseRequest}{IPX800v4CommandStrings.GetDigitalInput}";
        }
    }
}