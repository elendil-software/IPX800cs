using IPX800cs.IO;

namespace IPX800cs.Parsers.v5;

internal class IPX800V5GetDelayedOpenCollectorOutputsResponseParser : IPX800V5GetDelayedOutputsResponseParser
{
    public IPX800V5GetDelayedOpenCollectorOutputsResponseParser()
    {
        OutputType = OutputType.DelayedOpenCollectorOutput;
    }
}