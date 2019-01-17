using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers
{
    public interface IOutputResponseParser<out T>
    {
        T ParseResponse(string ipxResponse, int outputNumber);
    }
}