using IPX800cs.IO;

namespace IPX800cs.ActionsExecutors
{
    public interface ISetOutputExecutor
    {
        bool Execute(Output output);
    }
}