namespace IPX800cs.Parsers.v4.Http;

internal class IPX800V4GetVirtualGetAnalogInputHttpResponseParser : IGetAnalogInputResponseParser
{
    public double ParseResponse(string ipxResponse, int inputNumber)
    {
        return JsonParser.ParseValue(ipxResponse, $"VA{inputNumber}");
    }
}