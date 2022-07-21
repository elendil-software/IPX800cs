using IPX800cs.IO;

namespace IPX800cs.Parsers.v5;

internal class IPX800V5GetOpenCollectorOutputsResponseParser : IPX800V5GetOutputsResponseParser
{
    public IPX800V5GetOpenCollectorOutputsResponseParser()
    {
        MinId = 65568;
        MaxId = 65571;
        OutputType = OutputType.OpenCollectorOutput;
    }
}