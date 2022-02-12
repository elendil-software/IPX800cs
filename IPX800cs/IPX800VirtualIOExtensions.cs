using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs;

public static class IPX800VirtualIOExtensions
{
    public static InputState GetVirtualInput(this IIPX800 ipx800, int inputNumber)
    {
        return ipx800.GetInput(new Input
        {
            Number = inputNumber,
            Type = InputType.VirtualDigitalInput
        });
    }
    
    public static IEnumerable<InputResponse> GetVirtualInputs(this IIPX800 ipx800)
    {
        return ipx800.GetInputs(InputType.VirtualDigitalInput);
    }
    
    public static int GetVirtualAnalogInput(this IIPX800 ipx800, int inputNumber)
    {
        return ipx800.GetAnalogInput(new AnalogInput
        {
            Number = inputNumber,
            Type = AnalogInputType.VirtualAnalogInput
        });
    }
    
    public static IEnumerable<AnalogInputResponse> GetVirtualAnalogInputs(this IIPX800 ipx800)
    {
        return ipx800.GetAnalogInputs(AnalogInputType.VirtualAnalogInput);
    }
    
    public static OutputState GetVirtualOutput(this IIPX800 ipx800, int outputNumber)
    {
        return ipx800.GetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.VirtualOutput
        });
    }
    
    public static IEnumerable<OutputResponse> GetVirtualOutputs(this IIPX800 ipx800)
    {
        return ipx800.GetOutputs(OutputType.VirtualOutput);
    }
    
    public static IEnumerable<OutputResponse> GetDelayedVirtualOutputs(this IIPX800 ipx800)
    {
        return ipx800.GetOutputs(OutputType.DelayedVirtualOutput);
    }
    
    public static OutputState GetDelayedVirtualOutput(this IIPX800 ipx800, int outputNumber)
    {
        return ipx800.GetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.DelayedVirtualOutput
        });
    }
    
    public static bool SetVirtualOutput(this IIPX800 ipx800, int outputNumber, OutputState state)
    {
        return ipx800.SetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.VirtualOutput,
            State = state
        });
    }
    
    public static bool SetDelayedVirtualOutput(this IIPX800 ipx800, int outputNumber)
    {
        return ipx800.SetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.DelayedVirtualOutput,
            State = OutputState.Active
        });
    }
}