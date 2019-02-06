using IPX800cs.IO;

namespace IPX800cs.ActionsExecutors
{
    public interface IGetInputExecutor
    {
        InputState Execute(Input input);
    }
}