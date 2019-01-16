namespace software.elendil.IPX800.Parsers.v4.M2M
{
    public abstract class NonHeadedResponseParserBase
    {
        protected string ExtractValue(string responseString, int inputOutputNumber)
        {
            string result;

            //TODO : remplacer les & puis appliquer le substring
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