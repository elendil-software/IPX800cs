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
using software.elendil.IPX800.Enum;
using software.elendil.IPX800.Exceptions;

namespace software.elendil.IPX800.v4.M2M
{
	public class M2MResponseParser
	{
		/// <summary>
		/// Parses the response from a <see cref="IIPX800.GetAn" /> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <param name="inputNumber">The input number that need to be extracted from the answer</param>
		/// <returns>The parsed response</returns>
		public static string ParseGetAnResponse(string responseString, uint inputNumber)
		{
			var result = ParseResponse(responseString, 'A', inputNumber);
			return result;
		}

		/// <summary>
		/// Parses the response from a <see cref="IIPX800.GetOut" /> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <param name="outputNumber">The output number that need to be extracted from the answer</param>
		/// <returns>The parsed response</returns>
		public static OutputState ParseGetOutResponse(string responseString, uint outputNumber)
		{
			var result = ParseResponse(responseString, 'R', outputNumber);
			return (OutputState)System.Enum.Parse(typeof(OutputState), result);
		}

		/// <summary>
		/// Parses the response from a <see cref="IIPX800.GetIn" /> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <param name="inputNumber">The input number that need to be extracted from the answer</param>
		/// <returns>The parsed response</returns>
		public static InputState ParseGetInResponse(string responseString, uint inputNumber)
		{
			var result = ParseResponse(responseString, 'D', inputNumber);
			return (InputState)System.Enum.Parse(typeof(InputState), result);
		}

		/// <summary>
		/// Parses the response from a <see cref="IIPX800.SetOut" /> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns>The parsed response</returns>
		protected bool ParseSetOutResponse(string responseString)
		{
			var isSuccessful = "Success".Equals(responseString.Trim());
			return isSuccessful;
		}

		/// <summary>
		/// Determines whether <paramref name="responseString"/> is without header.
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns><c>true</c> if <paramref name="responseString"/> is without header; otherwise, <c>false</c>.</returns>
		private static bool IsWithoutHeader(string responseString)
		{
			var exp = new Regex("^([0-9&]*)$");
			var isWithoutHeader = exp.IsMatch(responseString);
			return isWithoutHeader;
		}

		private static string ParseResponse(string responseString, char type, uint outputNumber)
		{
			string result;
		    responseString = responseString.Trim();


            if (IsWithoutHeader(responseString))
			{
				result = ParseNonHeadedResponse(responseString, (int)outputNumber);
			}
			else
			{
				result = ParseHeadedResponse(responseString, type, outputNumber);
			}
			return result;
		}

		private static string ParseHeadedResponse(string responseString, char type, uint inOutNumber)
		{
			var matches = Regex.Matches(responseString, BuildRegexPatternString(type, inOutNumber));

			if (matches.Count == 1)
			{
				Match match = matches.OfType<Match>().ToArray().ElementAt(0);
				var result = match.Groups[1].Value;
				return result;
			}
			
			throw new IPX800ExecuteException("Unable to parse " + responseString + " response string");
		}

		private static string BuildRegexPatternString(char type, uint inOutNumber)
		{
			if (type == 'A')
			{
				return type + inOutNumber.ToString("D1") + "=([0-9\\.,]*)";
			}
			else
			{
				return type + inOutNumber.ToString("D2") + "=([0-9\\.,]*)";
			}
		}

		private static string ParseNonHeadedResponse(string responseString, int inOutNumber)
		{
			var result = "";

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

