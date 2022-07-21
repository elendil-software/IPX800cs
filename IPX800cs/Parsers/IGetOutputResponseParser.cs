using IPX800cs.IO;
#pragma warning disable CS1591

namespace IPX800cs.Parsers;

public interface IGetOutputResponseParser
{
    OutputState ParseResponse(string ipxResponse, int outputNumber);
}