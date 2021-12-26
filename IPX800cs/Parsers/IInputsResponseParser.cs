using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.Parsers;

public interface IInputsResponseParser
{
    IEnumerable<InputResponse> ParseResponse(string ipxResponse);
}