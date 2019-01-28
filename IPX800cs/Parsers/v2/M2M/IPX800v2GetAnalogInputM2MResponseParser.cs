namespace software.elendil.IPX800.Parsers.v2.M2M
{
    public class IPX800v2GetAnalogInputM2MResponseParser : IAnalogInputResponseParser
    {
        public double ParseResponse(string ipxResponse, int inputNumber)
        {
            var response = ipxResponse.Trim().Split('=');
            return double.Parse(response[1]);
        }
    }
}