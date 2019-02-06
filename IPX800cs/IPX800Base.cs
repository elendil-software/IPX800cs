using System;
using IPX800cs.ActionsExecutors;
using IPX800cs.Contracts;
using IPX800cs.IO;

namespace IPX800cs
{
    public abstract class IPX800Base : IIPX800
    {       
        protected readonly ISetOutputExecutor SetOutputExecutor;
        protected readonly IGetOutputExecutor GetOutputExecutor;
        protected readonly IGetInputExecutor GetInputExecutor;
        protected readonly IGetAnalogInputExecutor GetAnalogInputExecutor;

        protected IPX800Base(ISetOutputExecutor setOutputExecutor, IGetOutputExecutor getOutputExecutor, IGetInputExecutor getInputExecutor,
            IGetAnalogInputExecutor getAnalogInputExecutor)
        {
            SetOutputExecutor = setOutputExecutor ?? throw new ArgumentNullException(nameof(setOutputExecutor));
            GetOutputExecutor = getOutputExecutor ?? throw new ArgumentNullException(nameof(getOutputExecutor));
            GetInputExecutor = getInputExecutor ?? throw new ArgumentNullException(nameof(getInputExecutor));
            GetAnalogInputExecutor = getAnalogInputExecutor ?? throw new ArgumentNullException(nameof(getAnalogInputExecutor));
        }

        public InputState GetInput(int inputNumber)
        {
            return GetInputExecutor.Execute(new Input
            {
                Number = inputNumber,
                Type = InputType.DigitalInput
            });
        }

        public int GetAnalogInput(int inputNumber)
        {
            return GetAnalogInputExecutor.Execute(new Input
            {
                Number = inputNumber,
                Type = InputType.AnalogInput
            });
        }

        public OutputState GetOutput(int outputNumber)
        {
            return GetOutputExecutor.Execute(new Output
            {
                Number = outputNumber,
                Type = OutputType.Output
            });
        }

        public bool SetOutput(int outputNumber, OutputState state)
        {
            return SetOutputExecutor.Execute(new Output
            {
                Number = outputNumber,
                Type = OutputType.Output,
                State = state
            });
        }

        public bool SetDelayedOutput(int outputNumber)
        {
            return SetOutputExecutor.Execute(new Output
            {
                Number = outputNumber,
                Type = OutputType.Output,
                State = OutputState.Active,
                IsDelayed = true
            });
        }        
    }
}