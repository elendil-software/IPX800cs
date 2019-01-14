namespace software.elendil.IPX800.v4.M2M.Parsers
{
    public class VirtualAnalogResponseParser : ResponseParserBase, IResponseParser<string>
    {
        public string ParseResponse(string responseString, uint inputOutputNumber)
        {
            var result = ParseResponse(responseString, "VA", inputOutputNumber);
            return result;
        }

        protected override string BuildRegexPatternString(uint inOutNumber)
        {
            return "VA" + inOutNumber.ToString("D1") + "=([0-9\\.,]*)";
        }
    }
}