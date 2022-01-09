namespace IPX800cs.Parsers.v3.M2M;

internal class IPX800V3GetGetAnalogInputM2MResponseParser : IGetAnalogInputResponseParser
{
    public int ParseResponse(string ipxResponse, int inputNumber)
    {
        ipxResponse.CheckResponse();
        return int.Parse(ipxResponse.Trim());
    }
}