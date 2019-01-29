using System.Linq;
using System.Text.RegularExpressions;
using software.elendil.IPX800.Exceptions;

namespace software.elendil.IPX800.Parsers.v4.M2M
{
    public abstract class ResponseParserBase
    {
        protected string ExtractValue(string responseString, int inputOutputNumber)
        {
            string result;
            responseString = responseString.Trim();

            if (responseString.Contains("&"))
            {
                var splitedString = responseString.Split('&');
                result = splitedString[inputOutputNumber - 1];
            }
            else
            {
                result = responseString.Substring(inputOutputNumber - 1, 1);
            }

            return result;
        }

        protected string ExtractMatchingValue(string responseString, int inputOutputNumber, string pattern)
        {
            var matches = Regex.Matches(responseString, pattern);

            if (matches.Count == 1)
            {
                Match match = matches.OfType<Match>().ToArray().ElementAt(0);
                var result = match.Groups[1].Value;
                return result;
            }

            throw new IPX800CommandException($"Unable to parse '{responseString}' response string");
        }
    }
}