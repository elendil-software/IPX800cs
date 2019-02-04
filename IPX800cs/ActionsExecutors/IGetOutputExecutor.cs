using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.ActionsExecutors
{
    public interface IGetOutputExecutor
    {
        OutputState Execute(Output output);
    }
}