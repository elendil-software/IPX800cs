namespace IPX800cs.Parsers.v4.Http;

internal class IPX800v4GetVirtualAnalogInputHttpResponseParser : IAnalogInputResponseParser
{
    public int ParseResponse(string ipxResponse, int inputNumber)
    {
        return JsonParser.ParseValue(ipxResponse, $"VA{inputNumber}");
    }
}