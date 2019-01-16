using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers.v4.M2M
{
    public class OutputResponseParser : HeadedResponseParserBase, IResponseParser<OutputState, string>
    {
        public OutputState ParseResponse(string ipxResponse, int ioNumber)
        {
            var result = ExtractValue(ipxResponse, ioNumber);
            return (OutputState)System.Enum.Parse(typeof(OutputState), result);
        }

        protected override string BuildRegexPatternString(int inputOutputNumber)
        {
            //TODO remplacer la concaténation par une interpolation de chaine
            return "R" + inputOutputNumber.ToString("D2") + "=([0-9\\.,]*)";
        }
    }
}