using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.Parsers;

public interface IAnalogInputsResponseParser
{
    IEnumerable<AnalogInputResponse> ParseResponse(string ipxResponse);
}