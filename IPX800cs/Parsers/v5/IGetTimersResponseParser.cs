using System.Collections.Generic;
#pragma warning disable CS1591

namespace IPX800cs.Parsers.v5;

public interface IGetTimersResponseParser
{
    IEnumerable<TimerResponse> ParseResponse(string ipxResponse);
}