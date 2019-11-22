using System;
using System.Collections.Generic;
using IPX800cs.ActionsExecutors;
using IPX800cs.Contracts;
using IPX800cs.IO;

namespace IPX800cs
{
    public class IPX800v4 : IPX800Base, IIPX800v4
    {       
        private readonly IGetOutputsExecutor _getOutputsExecutor;
        private readonly IGetInputsExecutor _getInputsExecutor;
        private readonly IGetAnalogInputsExecutor _getAnalogInputsExecutor;
        
        internal IPX800v4(ISetOutputExecutor setOutputExecutor, IGetOutputExecutor getOutputExecutor, IGetOutputsExecutor getOutputsExecutor, 
            IGetInputExecutor getInputExecutor, IGetInputsExecutor getInputsExecutor, 
            IGetAnalogInputExecutor getAnalogInputExecutor, IGetAnalogInputsExecutor getAnalogInputsExecutor)
            : base(setOutputExecutor, getOutputExecutor, getInputExecutor, getAnalogInputExecutor)
        {
            _getOutputsExecutor = getOutputsExecutor ?? throw new ArgumentNullException(nameof(getOutputsExecutor));
            _getInputsExecutor = getInputsExecutor ?? throw new ArgumentNullException(nameof(getInputsExecutor));
            _getAnalogInputsExecutor = getAnalogInputsExecutor ?? throw new ArgumentNullException(nameof(getAnalogInputsExecutor));
        }
        
        public Dictionary<int, InputState> GetInputs()
        {
            return _getInputsExecutor.Execute(new Input
            {
                Type = InputType.DigitalInput
            });
        }
        
        public Dictionary<int, int> GetAnalogInputs()
        {
            return _getAnalogInputsExecutor.Execute(new Input
            {
                Type = InputType.AnalogInput
            });
        }
        
        public Dictionary<int, OutputState> GetOutputs()
        {
            return _getOutputsExecutor.Execute(new Output
            {
                Type = OutputType.Output
            });
        }
        
        public Dictionary<int, OutputState> GetVirtualOutputs()
        {
            return _getOutputsExecutor.Execute(new Output
            {
                Type = OutputType.VirtualOutput
            });
        }

        public InputState GetVirtualInput(int inputNumber)
        {
            return GetInputExecutor.Execute(new Input
            {
                Number = inputNumber,
                Type = InputType.VirtualDigitalInput
            });
        }
        
        public Dictionary<int, InputState> GetVirtualInputs()
        {
            return _getInputsExecutor.Execute(new Input
            {
                Type = InputType.VirtualDigitalInput
            });
        }
        
        public int GetVirtualAnalogInput(int inputNumber)
        {
            return GetAnalogInputExecutor.Execute(new Input
            {
                Number = inputNumber,
                Type = InputType.VirtualAnalogInput
            });
        }
        
        public Dictionary<int, int> GetVirtualAnalogInputs()
        {
            return _getAnalogInputsExecutor.Execute(new Input
            {
                Type = InputType.VirtualAnalogInput
            });
        }

        public OutputState GetVirtualOutput(int outputNumber)
        {
            return GetOutputExecutor.Execute(new Output
            {
                Number = outputNumber,
                Type = OutputType.VirtualOutput
            });
        }

        public bool SetVirtualOutput(int outputNumber, OutputState state)
        {
            return SetOutputExecutor.Execute(new Output
            {
                Number = outputNumber,
                Type = OutputType.VirtualOutput,
                State = state
            });
        }

        public bool SetDelayedVirtualOutput(int outputNumber)
        {
            return SetOutputExecutor.Execute(new Output
            {
                Number = outputNumber,
                Type = OutputType.VirtualOutput,
                State = OutputState.Active,
                IsDelayed = true
            });
        }
    }
}