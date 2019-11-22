using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.ActionsExecutors
{
    public interface IGetAnalogInputsExecutor
    {
        Dictionary<int, int> Execute(Input input);
    }
}