using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.ActionsExecutors
{
    public interface IGetInputsExecutor
    {
        Dictionary<int, InputState> Execute(Input input);
    }
}