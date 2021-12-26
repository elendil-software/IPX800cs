using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.Parsers;

public interface IGetOutputsResponseParser
{
    IEnumerable<OutputResponse> ParseResponse(string ipxResponse);
}