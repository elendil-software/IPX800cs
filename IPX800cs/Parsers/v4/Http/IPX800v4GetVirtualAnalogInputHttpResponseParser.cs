using Newtonsoft.Json.Linq;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetVirtualAnalogInputHttpResponseParser : IAnalogInputResponseParser
    {
        public double ParseResponse(string ipxResponse, int inputNumber)
        {
            JObject json = JObject.Parse(ipxResponse);
            string key = $"VA{inputNumber}";
            return double.Parse(json[key].ToString());
        }
    }
}