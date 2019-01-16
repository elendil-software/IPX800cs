using System.Linq;
using System.Text.RegularExpressions;
using software.elendil.IPX800.ipx800csV1.Exceptions;

namespace software.elendil.IPX800.ipx800csV1.v4.M2M.Parsers
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
                result = ParseHeadedResponse(responseString, outputNumber);
                
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
        
        protected string ParseHeadedResponse(string responseString, uint inOutNumber)
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