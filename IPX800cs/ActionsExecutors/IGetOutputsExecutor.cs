using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.ActionsExecutors
{
    public interface IGetOutputsExecutor
    {
        Dictionary<int, OutputState> Execute(Output output);
    }
}