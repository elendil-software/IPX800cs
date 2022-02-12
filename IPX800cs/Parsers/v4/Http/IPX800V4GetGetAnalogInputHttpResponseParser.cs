namespace IPX800cs.Parsers.v4.Http;

internal class IPX800V4GetGetAnalogInputHttpResponseParser : IGetAnalogInputResponseParser
{
    public double ParseResponse(string ipxResponse, int inputNumber)
    {
        return JsonParser.ParseValue(ipxResponse, $"A{inputNumber}");
    }
}