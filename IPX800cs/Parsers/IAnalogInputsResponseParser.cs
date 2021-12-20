using System.Collections.Generic;

namespace IPX800cs.Parsers;

public interface IAnalogInputsResponseParser
{
    Dictionary<int, int>  ParseResponse(string ipxResponse);
}