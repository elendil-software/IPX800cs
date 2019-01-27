using Newtonsoft.Json.Linq;

namespace software.elendil.IPX800.Parsers.v4.Http
{
    public class IPX800v4GetVirtualAnalogInputHttpResponseParser : IAnalogInputResponseParser
    {
        public double ParseResponse(string ipxResponse, int inputNumber)
        {
            JObject json = JObject.Parse(ipxResponse);
            string key = $"VA{inputNumber}";
            return double.Parse(json[key].ToString());
        }
    }
}