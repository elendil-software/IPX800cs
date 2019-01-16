﻿using System;
using software.elendil.IPX800.ipx800csV1.Enum;

namespace software.elendil.IPX800.ipx800csV1.v4.M2M.Parsers
{
    public class VirtualOutputResponseParser : ResponseParserBase, IResponseParser<OutputState>
    {
        public OutputState ParseResponse(string responseString, uint inputOutputNumber)
        {
            responseString = responseString.Replace("VO=", "");
            var result = ParseResponse(responseString, "VO", inputOutputNumber);
            return (OutputState)System.Enum.Parse(typeof(OutputState), result);
        }

        protected override string BuildRegexPatternString(uint inOutNumber)
        {
            throw new NotImplementedException("This method shouldn't be necessary for this parser");
        }
    }
}