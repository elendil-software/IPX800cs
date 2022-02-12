namespace IPX800cs.Parsers.v4.M2M;

internal class IPX800V4GetGetAnalogInputM2MResponseParser : ResponseParserBase, IGetAnalogInputResponseParser
{
    public double ParseResponse(string ipxResponse, int inputNumber)
    {
        return ParseValue(ipxResponse, inputNumber);
    }
}