using System.Text.RegularExpressions;
using IPX800cs.Exceptions;

namespace IPX800cs.Parsers.v3.M2M;

internal static class IPX800V3M2MResponseExtension 
{
    public static void CheckResponse(this string ipxResponse)
    {
        if (string.IsNullOrWhiteSpace(ipxResponse))
        {
            throw new IPX800InvalidResponseException(ipxResponse);
        }

        ipxResponse = ipxResponse.Trim();
            
        var numberOnlyRegex = new Regex("^[0-9]+$");

        if (!numberOnlyRegex.IsMatch(ipxResponse))
        {
            throw new IPX800InvalidResponseException(ipxResponse);   
        }
    }
}