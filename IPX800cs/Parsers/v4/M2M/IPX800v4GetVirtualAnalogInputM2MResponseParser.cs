namespace IPX800cs.Parsers.v4.M2M;

internal class IPX800v4GetVirtualAnalogInputM2MResponseParser : ResponseParserBase, IAnalogInputResponseParser
{
    public int ParseResponse(string ipxResponse, int inputNumber)
    {
        return ParseValue(ipxResponse, inputNumber);
    }
}