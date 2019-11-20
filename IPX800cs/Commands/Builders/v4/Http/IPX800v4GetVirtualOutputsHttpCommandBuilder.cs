namespace IPX800cs.Commands.Builders.v4.Http
{
    internal class IPX800v4GetVirtualOutputsHttpCommandBuilder : IGetOutputsCommandBuilder
    {
        public string BuildCommandString()
        {
            return $"{IPX800v4CommandStrings.HttpBaseRequest}{IPX800v4CommandStrings.GetVirtualOutput}";
        }
    }
}