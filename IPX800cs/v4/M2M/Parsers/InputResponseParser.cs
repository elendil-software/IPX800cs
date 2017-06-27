using software.elendil.IPX800.Enum;

namespace software.elendil.IPX800.v4.M2M.Parsers
{
    public class InputResponseParser : ResponseParserBase, IResponseParser<InputState>
    {
        public InputState ParseResponse(string responseString, uint inputOutputNumber)
        {
            var result = ParseResponse(responseString, "D", inputOutputNumber);
            return (InputState)System.Enum.Parse(typeof(InputState), result);
        }

        protected override string BuildRegexPatternString(uint inOutNumber)
        {
            return "D" + inOutNumber.ToString("D2") + "=([0-9\\.,]*)";
        }
    }
}