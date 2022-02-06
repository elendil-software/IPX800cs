using System.Collections.Generic;
using System.Linq;

namespace IPX800cs.Parsers.v5;

internal class IPX800V5GetTemposResponseParser : IGetTimersResponseParser
{
    public IEnumerable<TimerResponse> ParseResponse(string ipxResponse)
    {
        IEnumerable<TimerResponse> parsedTimers = ipxResponse.ParseCollectionTimers();
        return parsedTimers.Where(t => t.Func == "tempo");
    }
}