using IPX800cs.IO;

namespace IPX800cs.Parsers.v5;

internal class IPX800V5GetInputResponseParser : IGetInputResponseParser
{
    public InputState ParseResponse(string ipxResponse, int inputNumber)
    {
        IOResponse response = ipxResponse.ParseIO();
        return response.On ? InputState.Active : InputState.Inactive;
    }
}