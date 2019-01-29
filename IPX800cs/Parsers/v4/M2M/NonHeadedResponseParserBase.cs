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
    }
}