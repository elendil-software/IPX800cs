using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers
{
    public interface IInputResponseParser
    {
        InputState ParseResponse(string ipxResponse, int inputNumber);
    }
}