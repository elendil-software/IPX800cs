using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using IPX800cs.Exceptions;

namespace IPX800cs.Parsers;

internal static class JsonParser
{
    public static int ParseValue(string ipxResponse, string key)
    {
        try
        {
            JsonDocument json = Parse(ipxResponse);
            int value = json.RootElement.GetProperty(key).GetInt32();
            
            return value;
        }
        catch (Exception ex)
        {
            throw new IPX800InvalidResponseException(ipxResponse, ex); 
        }
    }
        
    public static Dictionary<int, int> ParseCollection(string ipxResponse, string prefix)
    {
        try
        {
            JsonDocument json = JsonParser.Parse(ipxResponse);

            Dictionary<int, int> inputStates = json.RootElement.EnumerateObject()
                .Where(p => p.Name.StartsWith(prefix))
                .ToDictionary(p => int.Parse(p.Name.Substring(prefix.Length)), p => p.Value.GetInt32());
            
            return inputStates;
        }
        catch (Exception ex)
        {
            throw new IPX800InvalidResponseException(ipxResponse, ex); 
        }
    }
        
    public static JsonDocument Parse(string jsonString)
    {
        ThrowExceptionIfJsonIsEmpty(jsonString);
        
        try
        {
            return JsonDocument.Parse(jsonString);
        }
        catch (Exception ex)
        {
            throw new IPX800InvalidResponseException(jsonString, ex); 
        }
    }

    private static void ThrowExceptionIfJsonIsEmpty(string jsonString)
    {
        string trimJsonString = jsonString?.Trim();
        
        if (trimJsonString is "{}" or "[]")
        {
            throw new IPX800InvalidResponseException(jsonString);
        }
    }
}