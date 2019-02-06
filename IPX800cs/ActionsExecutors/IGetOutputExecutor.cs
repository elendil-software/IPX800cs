using IPX800cs.IO;

namespace IPX800cs.ActionsExecutors
{
    public interface IGetOutputExecutor
    {
        OutputState Execute(Output output);
    }
}