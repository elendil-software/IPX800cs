using System.Text.RegularExpressions;
using IPX800cs.Exceptions;

namespace IPX800cs.Parsers.v4.M2M
{
    internal static class IpxResponseExtension 
    {
        public static ResponseType CheckAndGetResponseType(this string ipxResponse)
        {
            if (string.IsNullOrWhiteSpace(ipxResponse))
            {
                throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response");
            }

            ipxResponse = ipxResponse.Trim();
            
            var numberOnlyRegex = new Regex("^[0-9]+$");
            var withHeaderRegex = new Regex("^([a-zA-Z0-9]+=[0-9]+&?)+$");
            var withoutHeaderRegex = new Regex("^([0-9]+&?)+$");

            if (numberOnlyRegex.IsMatch(ipxResponse))
            {
                return ResponseType.NumberOnly;
            }

            if (withoutHeaderRegex.IsMatch(ipxResponse))
            {
                return ResponseType.WithoutHeader;
            }
            
            if (withHeaderRegex.IsMatch(ipxResponse))
            {
                return ResponseType.WithHeader;
            }

            throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response");
        }
    }
}