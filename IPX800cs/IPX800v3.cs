using System;
using software.elendil.IPX800.ActionsExecutors;
using software.elendil.IPX800.Contracts;

namespace software.elendil.IPX800
{
    public class IPX800v3 : IPX800Base, IIPX800v3
    {
        private readonly IGetVersionExecutor _getVersionExecutor;
        
        internal IPX800v3(ISetOutputExecutor setOutputExecutor, IGetOutputExecutor getOutputExecutor, IGetInputExecutor getInputExecutor,
            IGetAnalogInputExecutor getAnalogInputExecutor, IGetVersionExecutor versionExecutor) : base(setOutputExecutor, getOutputExecutor,
            getInputExecutor, getAnalogInputExecutor)
        {
            _getVersionExecutor = versionExecutor ?? throw new ArgumentNullException(nameof(versionExecutor));
        }

        public System.Version GetVersion()
        {
            return _getVersionExecutor.Execute();
        }
    }
}