using IPX800cs.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal static class JsonParser
    {
        public static JObject Parse(string jsonString)
        {
            try
            {
                JObject json = JObject.Parse(jsonString);

                if (json.Count == 0)
                {
                    throw new IPX800InvalidResponseException($"'{jsonString}' is not a valid response");
                }

                return json;
            }
            catch (JsonReaderException ex)
            {
                throw new IPX800InvalidResponseException($"'{jsonString}' is not a valid response", ex); 
            }
        }
    }
}