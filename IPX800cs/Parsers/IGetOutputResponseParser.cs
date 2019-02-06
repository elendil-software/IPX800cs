using IPX800cs.IO;

namespace IPX800cs.Parsers
{
    public interface IGetOutputResponseParser
    {
        OutputState ParseResponse(string ipxResponse, int outputNumber);
    }
}