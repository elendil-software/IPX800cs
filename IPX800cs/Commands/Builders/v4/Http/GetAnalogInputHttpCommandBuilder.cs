using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4.Http
{
    public class GetAnalogInputHttpCommandBuilder : HttpCommandBuilderBase, IGetInCommandBuilder
    {
        public string BuildCommandString(IPX800Input input)
        {
            return $"{baseRequest}{IPX800v4CommandStrings.GetAnalogInput}";
        }
    }
}