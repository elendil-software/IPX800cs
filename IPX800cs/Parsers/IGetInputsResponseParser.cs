using System.Collections.Generic;
using IPX800cs.IO;
#pragma warning disable CS1591

namespace IPX800cs.Parsers;

public interface IGetInputsResponseParser
{
    IEnumerable<InputResponse> ParseResponse(string ipxResponse);
}