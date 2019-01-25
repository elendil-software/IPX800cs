using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers
{
    public interface IGetOutputResponseParser
    {
        OutputState ParseResponse(string ipxResponse, int outputNumber);
    }
}