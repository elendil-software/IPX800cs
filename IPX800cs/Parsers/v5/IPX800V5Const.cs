using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v5;

internal static class IPX800V5Const
{
    public static readonly Dictionary<OutputType, List<int>> IOIds = new()
    {
        { OutputType.Output, new List<int> { 65536, 65543 } },
        { OutputType.DelayedOutput, new List<int> { 65536, 65543 } },
        { OutputType.OpenCollectorOutput, new List<int> { 65568, 65571 } },
        { OutputType.DelayedOpenCollectorOutput, new List<int> { 65568, 65571 } },
        { OutputType.DelayedVirtualOutput, new List<int> { 65576, int.MaxValue } }
    };
}