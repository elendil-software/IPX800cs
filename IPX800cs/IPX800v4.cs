using software.elendil.IPX800.ActionsExecutors;
using software.elendil.IPX800.Contracts;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800
{
    public class IPX800v4 : IPX800Base, IIPX800v4
    {
        private readonly GetVersionExecutor _getVersionExecutor;
        
        public IPX800v4(Context context) : base(context)
        {
            _getVersionExecutor = new GetVersionExecutor(context);
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
                Type = OutputType.Output,
                State = state
            });
        }

        public bool SetDelayedVirtualOutput(int outputNumber)
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