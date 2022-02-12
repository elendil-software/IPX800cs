using System.Collections.Generic;

namespace IPX800cs.Parsers.v5;

public interface IGetTimersResponseParser
{
    IEnumerable<TimerResponse> ParseResponse(string ipxResponse);
}