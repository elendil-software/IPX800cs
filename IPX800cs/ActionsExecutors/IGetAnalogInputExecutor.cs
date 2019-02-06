using IPX800cs.IO;

namespace IPX800cs.ActionsExecutors
{
    public interface IGetAnalogInputExecutor
    {
        double Execute(Input input);
    }
}