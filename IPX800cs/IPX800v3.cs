using System;
using System.Collections.Generic;
using IPX800cs.ActionsExecutors;
using IPX800cs.Contracts;
using IPX800cs.IO;

namespace IPX800cs
{
    public class IPX800v3 : IPX800Base, IIPX800v3
    {
        private readonly IGetVersionExecutor _getVersionExecutor;
        private readonly IGetOutputsExecutor _getOutputsExecutor;
        private readonly IGetInputsExecutor _getInputsExecutor;
        
        internal IPX800v3(ISetOutputExecutor setOutputExecutor, IGetOutputExecutor getOutputExecutor, IGetOutputsExecutor getOutputsExecutor, 
            IGetInputExecutor getInputExecutor, IGetInputsExecutor getInputsExecutor, IGetAnalogInputExecutor getAnalogInputExecutor, 
            IGetVersionExecutor versionExecutor) : base(setOutputExecutor, getOutputExecutor,
            getInputExecutor, getAnalogInputExecutor)
        {
            _getVersionExecutor = versionExecutor ?? throw new ArgumentNullException(nameof(versionExecutor));
            _getOutputsExecutor = getOutputsExecutor ?? throw new ArgumentNullException(nameof(getOutputsExecutor));
            _getInputsExecutor = getInputsExecutor ?? throw new ArgumentNullException(nameof(getInputsExecutor));
        }

        public System.Version GetVersion()
        {
            return _getVersionExecutor.Execute();
        }

        public Dictionary<int, InputState> GetInputs()
        {
            return _getInputsExecutor.Execute(new Input
            {
                Type = InputType.DigitalInput
            });
        }

        public Dictionary<int, OutputState> GetOutputs()
        {
            return _getOutputsExecutor.Execute(new Output
            {
                Type = OutputType.Output
            });
        }
    }
}