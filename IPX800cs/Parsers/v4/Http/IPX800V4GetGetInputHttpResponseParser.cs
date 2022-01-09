using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.Http;

internal class IPX800V4GetGetInputHttpResponseParser : IGetInputResponseParser
{
    public InputState ParseResponse(string ipxResponse, int inputNumber)
    {
        return (InputState) JsonParser.ParseValue(ipxResponse, $"D{inputNumber}");
    }
}