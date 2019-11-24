using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.Parsers
{
    public interface IGetOutputsResponseParser
    {
        Dictionary<int, OutputState> ParseResponse(string ipxResponse);
    }
}