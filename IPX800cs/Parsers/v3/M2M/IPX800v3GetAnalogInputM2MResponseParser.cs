namespace software.elendil.IPX800.Parsers.v3.M2M
{
    public class IPX800v3GetAnalogInputM2MResponseParser : IAnalogInputResponseParser
    {
        public double ParseResponse(string ipxResponse, int inputNumber)
        {
            return double.Parse(ipxResponse.Trim());
        }
    }
}