namespace IPX800cs.Parsers.v3.M2M
{
    internal class IPX800v3GetAnalogInputM2MResponseParser : IAnalogInputResponseParser
    {
        public double ParseResponse(string ipxResponse, int inputNumber)
        {
            return double.Parse(ipxResponse.Trim());
        }
    }
}