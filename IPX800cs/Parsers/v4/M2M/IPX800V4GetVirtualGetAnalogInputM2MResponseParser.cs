namespace IPX800cs.Parsers.v4.M2M;

internal class IPX800V4GetVirtualGetAnalogInputM2MResponseParser : ResponseParserBase, IGetAnalogInputResponseParser
{
    public int ParseResponse(string ipxResponse, int inputNumber)
    {
        return ParseValue(ipxResponse, inputNumber);
    }
}