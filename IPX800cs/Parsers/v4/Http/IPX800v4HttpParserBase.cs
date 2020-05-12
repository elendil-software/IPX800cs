using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal abstract class IPX800v4HttpParserBase
    {
        protected int ParseValue(string ipxResponse, string key)
        {
            JObject json = JsonParser.Parse(ipxResponse);
            string strValue = json[key]?.ToString();
            
            if (strValue == null)
            {
                throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response");
            }
            
            return int.Parse(strValue);
        }
        
        protected static Dictionary<int, int> ParseCollection(string ipxResponse, string prefix)
        {
            JObject json = JsonParser.Parse(ipxResponse);

            Dictionary<int, int> inputStates = json.Properties()
                .Where(p => p.Name.StartsWith(prefix))
                .ToDictionary(p => int.Parse(p.Name.Substring(prefix.Length)), p => (int) p.Value);
            return inputStates;
        }
    }
}