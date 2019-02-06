using IPX800cs.ActionsExecutors;
using IPX800cs.Contracts;

namespace IPX800cs
{
    public class IPX800v2 : IPX800v3, IIPX800v2
    {        
        internal IPX800v2(ISetOutputExecutor setOutputExecutor, IGetOutputExecutor getOutputExecutor, IGetInputExecutor getInputExecutor,
            IGetAnalogInputExecutor getAnalogInputExecutor, IGetVersionExecutor getVersionExecutor) : base(setOutputExecutor, getOutputExecutor,
            getInputExecutor, getAnalogInputExecutor, getVersionExecutor)
        {
        }
    }
}