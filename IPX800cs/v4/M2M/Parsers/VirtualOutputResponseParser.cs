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

using System;
using software.elendil.IPX800.Enum;
using software.elendil.IPX800.Exceptions;

namespace software.elendil.IPX800.v4.M2M.Parsers
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