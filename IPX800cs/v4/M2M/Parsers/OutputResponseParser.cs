// This file is part of IPX800 C#.
// Copyright (c) Julien TSCHAPPAT, All rights reserved.
// 
// IPX800 C# is free software; you can redistribute it and/or modify 
// it under the terms of the GNU Lesser General Public License as published by 
// the Free Software Foundation; either version 3.0 of the License, or 
// (at your option) any later version.
// 
// IPX800 C# is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with IPX800 C#. If not, see <https://www.gnu.org/licenses/lgpl.html>
using software.elendil.IPX800.Enum;

namespace software.elendil.IPX800.v4.M2M.Parsers
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