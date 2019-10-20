using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.Parsers
{
    public interface IInputsResponseParser
    {
        Dictionary<int, InputState> ParseResponse(string ipxResponse);
    }
}