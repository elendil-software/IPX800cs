using System.Text.RegularExpressions;
using IPX800cs.Exceptions;

namespace IPX800cs.Parsers.v3.Legacy.M2M
{
    internal static class IpxResponseExtension 
    {
        public static void CheckResponse(this string ipxResponse)
        {
            if (string.IsNullOrWhiteSpace(ipxResponse))
            {
                throw new IPX800InvalidResponseException(ipxResponse);
            }

            ipxResponse = ipxResponse.Trim();
            var m2mLegacyResponseRegex = new Regex("^([a-zA-Z0-9]+=[0-9]+)$");

            if (!m2mLegacyResponseRegex.IsMatch(ipxResponse))
            {
                throw new IPX800InvalidResponseException(ipxResponse);   
            }
        }
    }
}