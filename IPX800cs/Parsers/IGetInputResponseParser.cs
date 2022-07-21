using IPX800cs.IO;
#pragma warning disable CS1591

namespace IPX800cs.Parsers;

public interface IGetInputResponseParser
{
    InputState ParseResponse(string ipxResponse, int inputNumber);
}