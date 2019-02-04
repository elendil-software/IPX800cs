using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.ActionsExecutors
{
    public interface IGetInputExecutor
    {
        InputState Execute(Input input);
    }
}