using System.Linq;
using System.Text.RegularExpressions;
using software.elendil.IPX800.Exceptions;

namespace software.elendil.IPX800.Parsers.v4.M2M
{
    public abstract class HeadedResponseParserBase
    {
        protected abstract string BuildRegexPatternString(int inputOutputNumber);
               
        protected string ExtractValue(string responseString, int inputOutputNumber)
        {
            var matches = Regex.Matches(responseString, BuildRegexPatternString(inputOutputNumber));

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