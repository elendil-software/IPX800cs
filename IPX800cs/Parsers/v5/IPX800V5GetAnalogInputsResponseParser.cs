using System;
using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v5;

internal class IPX800V5GetAnalogInputsResponseParser : IAnalogInputsResponseParser
{
    public IEnumerable<AnalogInputResponse> ParseResponse(string ipxResponse)
    {
        throw new NotImplementedException();
    }
}