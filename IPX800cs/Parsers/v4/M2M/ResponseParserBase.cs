using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;

namespace IPX800cs.Parsers.v4.M2M
{
    public abstract class ResponseParserBase
    {
        protected Dictionary<int, int> ParseCollection(string ipxResponse, string prefix)
        {
            ResponseType responseType = ipxResponse.CheckAndGetResponseType();

            switch (responseType)
            {
                case ResponseType.NumberOnly:
                    return ParseCollectionFromNumberOnlyResponse(ipxResponse);
                
                case ResponseType.WithoutHeader:
                    return ParseCollectionFromResponseWithoutHeader(ipxResponse);

                case ResponseType.WithHeader:
                    return ParseCollectionFromResponseWithHeaders(ipxResponse, prefix);
                
                default:
                    throw new IPX800InvalidResponseException(ipxResponse);
            }
        }

        private static Dictionary<int, int> ParseCollectionFromResponseWithHeaders(string ipxResponse, string prefix)
        {
            string[] splitResponse = ipxResponse.Split('&');

            Dictionary<int, int> values = splitResponse
                .Select(e => e.Split('='))
                .ToDictionary(e => int.Parse(e[0].Substring(prefix.Length)), e => int.Parse(e[1]));

            return values;
        }
        
        private static Dictionary<int, int> ParseCollectionFromResponseWithoutHeader(string ipxResponse)
        {
            string[] splitResponse = ipxResponse.Trim().Split('&');

            var values = new Dictionary<int, int>();
            int key = 1;

            foreach (string value in splitResponse)
            {
                values.Add(key, int.Parse(value));
                key++;
            }

            return values;
        }

        private Dictionary<int, int> ParseCollectionFromNumberOnlyResponse(string ipxResponse)
        {
            var values = new Dictionary<int, int>();
            int key = 1;

            foreach (char c in ipxResponse.Trim())
            {
                values.Add(key, int.Parse(c.ToString()));
                key++;
            }

            return values;
        }

        protected int ParseValue(string responseString, int inputOutputNumber)
        {
            ResponseType responseType = responseString.CheckAndGetResponseType();
            responseString = responseString.Trim();
            
            string stringValue = responseType == ResponseType.NumberOnly ? 
                ParseValueFromNumberOnlyResponse(responseString, inputOutputNumber) : 
                ParseValueFromResponse(responseString, inputOutputNumber, responseType);

            if (int.TryParse(stringValue, out int value))
            {
                return value;
            }

            throw new IPX800InvalidResponseException(responseString);
        }

        private static string ParseValueFromResponse(string responseString, int inputOutputNumber, ResponseType responseType)
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

        private string ParseValueFromNumberOnlyResponse(string responseString, int inputOutputNumber)
        {
            return responseString.Substring(inputOutputNumber - 1, 1);
        }
    }
}