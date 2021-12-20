using IPX800cs.IO;

namespace IPX800cs.Parsers;

public interface IInputResponseParser
{
    InputState ParseResponse(string ipxResponse, int inputNumber);
}