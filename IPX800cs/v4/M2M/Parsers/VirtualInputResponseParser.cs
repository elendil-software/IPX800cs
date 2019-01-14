using System;
using software.elendil.IPX800.Enum;

namespace software.elendil.IPX800.v4.M2M.Parsers
{
    public class VirtualInputResponseParser : ResponseParserBase, IResponseParser<InputState>
    {
        public InputState ParseResponse(string responseString, uint inputOutputNumber)
        {
            responseString = responseString.Replace("VI=", "");
            var result = ParseResponse(responseString, "VI", inputOutputNumber);
            return (InputState)System.Enum.Parse(typeof(InputState), result);
        }

        protected override string BuildRegexPatternString(uint inOutNumber)
        {
            throw new NotImplementedException("This method shouldn't be necessary for this parser");
        }
    }
}