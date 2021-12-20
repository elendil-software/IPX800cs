namespace IPX800cs.Parsers.v4.Http;

internal class IPX800v4GetAnalogInputHttpResponseParser : IAnalogInputResponseParser
{
    public int ParseResponse(string ipxResponse, int inputNumber)
    {
        return JsonParser.ParseValue(ipxResponse, $"A{inputNumber}");
    }
}