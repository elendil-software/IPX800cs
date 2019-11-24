using System;
using IPX800cs.ActionsExecutors;
using IPX800cs.Contracts;

namespace IPX800cs
{
    public class IPX800v2 : IPX800Base, IIPX800v2
    {        
        private readonly IGetVersionExecutor _getVersionExecutor;
        
        internal IPX800v2(ISetOutputExecutor setOutputExecutor, IGetOutputExecutor getOutputExecutor, IGetInputExecutor getInputExecutor,
            IGetAnalogInputExecutor getAnalogInputExecutor, IGetVersionExecutor getVersionExecutor) : base(setOutputExecutor, getOutputExecutor,
            getInputExecutor, getAnalogInputExecutor)
        {
            _getVersionExecutor = getVersionExecutor ?? throw new ArgumentNullException(nameof(getVersionExecutor));
        }
        
        public System.Version GetVersion()
        {
            return _getVersionExecutor.Execute();
        }
    }
}