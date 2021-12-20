using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.Http;

internal class IPX800v4GetVirtualInputHttpResponseParser : IInputResponseParser
{
    public InputState ParseResponse(string ipxResponse, int inputNumber)
    {
        return (InputState) JsonParser.ParseValue(ipxResponse, $"VI{inputNumber}");
    }
}