using software.elendil.IPX800.ipx800csV1.Enum;

namespace software.elendil.IPX800.ipx800csV1.v4.M2M.Parsers
{
    public class OutputResponseParser : ResponseParserBase, IResponseParser<OutputState>
    {
        public OutputState ParseResponse(string responseString, uint inputOutputNumber)
        {
            var result = ParseResponse(responseString, "R", inputOutputNumber);
            return (OutputState)System.Enum.Parse(typeof(OutputState), result);
        }

        protected override string BuildRegexPatternString(uint inOutNumber)
        {
            return "R" + inOutNumber.ToString("D2") + "=([0-9\\.,]*)";
        }
    }
}