namespace IPX800cs.Parsers.v3.Legacy.M2M
{
    internal class IPX800v3LegacyGetAnalogInputM2MResponseParser : IAnalogInputResponseParser
    {
        public double ParseResponse(string ipxResponse, int inputNumber)
        {
            var response = ipxResponse.Trim().Split('=');
            return double.Parse(response[1]);
        }
    }
}