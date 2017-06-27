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