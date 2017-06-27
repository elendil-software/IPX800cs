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
using System.Linq;
using System.Text.RegularExpressions;
using software.elendil.IPX800.Exceptions;

namespace software.elendil.IPX800.v4.M2M.Parsers
{
    public abstract class ResponseParserBase
    {
        protected abstract string BuildRegexPatternString(uint inOutNumber);


        protected string ParseResponse(string responseString, string type, uint outputNumber)
        {
            string result;
            responseString = responseString.Trim();


            if (HasHeader(responseString))
            {
                result = ParseHeadedResponse(responseString, type, outputNumber);
                
            }
            else
            {
                result = ParseNonHeadedResponse(responseString, (int)outputNumber);
            }

            return result;
        }


        /// <summary>
		/// Determines whether <paramref name="responseString"/> is without header.
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns><c>true</c> if <paramref name="responseString"/> is without header; otherwise, <c>false</c>.</returns>
		protected bool HasHeader(string responseString)
        {
            var exp = new Regex("^([0-9&]*)$");
            var isWithoutHeader = exp.IsMatch(responseString);
            return !isWithoutHeader;
        }
        
        protected string ParseHeadedResponse(string responseString, string type, uint inOutNumber)
        {
            var matches = Regex.Matches(responseString, BuildRegexPatternString(inOutNumber));

            if (matches.Count == 1)
            {
                Match match = matches.OfType<Match>().ToArray().ElementAt(0);
                var result = match.Groups[1].Value;
                return result;
            }

            throw new IPX800ExecuteException("Unable to parse " + responseString + " response string");
        }

        protected string ParseNonHeadedResponse(string responseString, int inOutNumber)
        {
            string result;

            if (responseString.Contains("&"))
            {
                var splitedString = responseString.Split('&');
                result = splitedString[inOutNumber - 1];
            }
            else
            {
                result = responseString.Substring(inOutNumber - 1, 1);
            }

            return result;
        }
    }
}