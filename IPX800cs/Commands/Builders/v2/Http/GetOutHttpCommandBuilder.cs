using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v2.Http
{
    public class GetOutHttpCommandBuilder : IGetOutCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            return IPX800v2HttpCommandStrings.GetOutput;
        }
    }
}