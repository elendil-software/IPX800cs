namespace software.elendil.IPX800.ipx800csV1.v4.M2M.Parsers
{
    public class AnalogResponseParser : ResponseParserBase, IResponseParser<string>
    {
        public string ParseResponse(string responseString, uint inputOutputNumber)
        {
            var result = ParseResponse(responseString, "A", inputOutputNumber);
            return result;
        }

        protected override string BuildRegexPatternString(uint inOutNumber)
        {
            return "A" + inOutNumber.ToString("D1") + "=([0-9\\.,]*)";
        }
    }
}