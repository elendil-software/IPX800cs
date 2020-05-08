using IPX800cs.Exceptions;

namespace IPX800cs.Parsers.v4.M2M
{
    public abstract class ResponseParserBase
    {
        protected int ExtractValue(string responseString, int inputOutputNumber)
        {
            ResponseType responseType = responseString.CheckAndGetResponseType();
            responseString = responseString.Trim();
            
            string stringValue = responseType == ResponseType.NumberOnly ? 
                ExtractFromNumberOnlyResponse(responseString, inputOutputNumber) : 
                ExtractFromSeparatedResponse(responseString, inputOutputNumber, responseType);

            if (int.TryParse(stringValue, out int value))
            {
                return value;
            }

            throw new IPX800InvalidResponseException($"'{responseString}' is not a valid response");
        }

        private static string ExtractFromSeparatedResponse(string responseString, int inputOutputNumber, ResponseType responseType)
        {
            var splitString = responseString.Split('&');
            var resultString = splitString[inputOutputNumber - 1];

            if (responseType == ResponseType.WithHeader)
            {
                var splitResult = resultString.Split('=');
                return splitResult[1];
            }

            return splitString[inputOutputNumber - 1];
        }

        private static string ExtractFromNumberOnlyResponse(string responseString, int inputOutputNumber)
        {
            return responseString.Substring(inputOutputNumber - 1, 1);
        }
    }
}