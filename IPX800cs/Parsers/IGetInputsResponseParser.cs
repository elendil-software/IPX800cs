using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.Parsers;

public interface IGetInputsResponseParser
{
    IEnumerable<InputResponse> ParseResponse(string ipxResponse);
}