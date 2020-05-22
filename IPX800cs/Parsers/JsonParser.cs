using System;
using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers
{
    internal static class JsonParser
    {
        public static int ParseValue(string ipxResponse, string key)
        {
            JObject json = Parse(ipxResponse);
            string strValue = json[key]?.ToString();
            
            if (strValue == null)
            {
                throw new IPX800InvalidResponseException(ipxResponse);
            }

            if (int.TryParse(strValue, out int value))
            {
                return value;
            }
            else
            {
                throw new IPX800InvalidResponseException(ipxResponse);
            }
        }
        
        public static Dictionary<int, int> ParseCollection(string ipxResponse, string prefix)
        {
            JObject json = JsonParser.Parse(ipxResponse);

            Dictionary<int, int> inputStates = json.Properties()
                .Where(p => p.Name.StartsWith(prefix))
                .ToDictionary(p => int.Parse(p.Name.Substring(prefix.Length)), p => (int) p.Value);
            return inputStates;
        }
        
        public static JObject Parse(string jsonString)
        {
            if (string.IsNullOrWhiteSpace(jsonString))
            {
                throw new IPX800InvalidResponseException(jsonString);
            }
            
            try
            {
                JObject json = JObject.Parse(jsonString);

                if (json.Count == 0)
                {
                    throw new IPX800InvalidResponseException(jsonString);
                }

                return json;
            }
            catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
            {
                throw new IPX800InvalidResponseException(jsonString, ex); 
            }
        }
    }
}