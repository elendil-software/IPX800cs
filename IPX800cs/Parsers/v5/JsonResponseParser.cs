using System;
using System.Collections.Generic;
using IPX800cs.Exceptions;
using Newtonsoft.Json;

namespace IPX800cs.Parsers.v5;

internal static class JsonResponseParser
{
    public static IEnumerable<IOResponse> ParseIO(this string jsonResponse)
    {
        return Parse<IOResponse>(jsonResponse);
    }
    
    public static IEnumerable<AnaResponse> ParseAna(this string jsonResponse)
    {
        return Parse<AnaResponse>(jsonResponse);
    }

    private static IEnumerable<T> Parse<T>(string jsonResponse) where T : class
    {
        try
        {
            var parsedResponse = JsonConvert.DeserializeObject<List<T>>(jsonResponse);
            if (parsedResponse == null || parsedResponse.Count == 0)
            {
                throw new IPX800InvalidResponseException($"JSON response is not valid : {jsonResponse}");
            }

            return parsedResponse;
        }
        catch (Exception e) when (e is not IPX800InvalidResponseException)
        {
            throw new IPX800InvalidResponseException(e.Message, e);
        }
    }
}