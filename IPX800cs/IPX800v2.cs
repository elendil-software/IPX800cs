using software.elendil.IPX800.ActionsExecutors;
using software.elendil.IPX800.Contracts;

namespace software.elendil.IPX800
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