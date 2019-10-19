namespace IPX800cs.Commands.Builders.v3.Legacy.Http
{
    internal class IPX800v3LegacyGetOutputsHttpCommandBuilder : IGetOutputsCommandBuilder
    {
        public string BuildCommandString()
        {
            return IPX800v3LegacyHttpCommandStrings.GetOutputs;
        }
    }
}