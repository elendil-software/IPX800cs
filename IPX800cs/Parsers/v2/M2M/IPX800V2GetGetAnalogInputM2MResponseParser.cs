namespace IPX800cs.Parsers.v2.M2M;

internal class IPX800V2GetGetAnalogInputM2MResponseParser : IPX800V2M2MParserBase, IGetAnalogInputResponseParser
{
    public double ParseResponse(string ipxResponse, int inputNumber)
    {
        ipxResponse.CheckResponse();
        return ParseValue(ipxResponse);
    }
}