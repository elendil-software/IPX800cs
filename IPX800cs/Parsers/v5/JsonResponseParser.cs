using System;
using System.Collections.Generic;
using IPX800cs.Exceptions;
using Newtonsoft.Json;

namespace IPX800cs.Parsers.v5;

internal static class JsonResponseParser
{
    public static IOResponse ParseIO(this string jsonResponse)
    {
        return Parse<IOResponse>(jsonResponse);
    }
    
    public static IEnumerable<IOResponse> ParseCollectionIO(this string jsonResponse)
    {
        return ParseCollection<IOResponse>(jsonResponse);
    }
    
    public static AnaResponse ParseAna(this string jsonResponse)
    {
        return Parse<AnaResponse>(jsonResponse);
    }
    
    public static IEnumerable<AnaResponse> ParseCollectionAna(this string jsonResponse)
    {
        return ParseCollection<AnaResponse>(jsonResponse);
    }

    private static List<T> ParseCollection<T>(string jsonResponse) where T : class
    {
        var parsedResponse = Parse<List<T>>(jsonResponse);
        if (parsedResponse.Count == 0)
        {
            throw new IPX800InvalidResponseException($"JSON response is not valid : {jsonResponse}");
        }

        return parsedResponse;
    }

    private static T Parse<T>(string jsonResponse) where T : class
    {
        try
        {
            var parsedResponse = JsonConvert.DeserializeObject<T>(jsonResponse);
            if (parsedResponse == null)
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