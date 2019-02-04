using software.elendil.IPX800.ActionsExecutors;
using software.elendil.IPX800.Contracts;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800
{
    public class IPX800v4 : IPX800Base, IIPX800v4
    {       
        internal IPX800v4(ISetOutputExecutor setOutputExecutor, IGetOutputExecutor getOutputExecutor, IGetInputExecutor getInputExecutor,
            IGetAnalogInputExecutor getAnalogInputExecutor) : base(setOutputExecutor, getOutputExecutor,
            getInputExecutor, getAnalogInputExecutor)
        {
        }

        public InputState GetVirtualInput(int inputNumber)
        {
            return GetInputExecutor.Execute(new Input
            {
                Number = inputNumber,
                Type = InputType.VirtualDigitalInput
            });
        }
        
        public double GetVirtualAnalogInput(int inputNumber)
        {
            return GetAnalogInputExecutor.Execute(new Input
            {
                Number = inputNumber,
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