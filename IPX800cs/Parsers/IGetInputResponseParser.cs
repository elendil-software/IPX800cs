using IPX800cs.IO;

namespace IPX800cs.Parsers;

public interface IGetInputResponseParser
{
    InputState ParseResponse(string ipxResponse, int inputNumber);
}