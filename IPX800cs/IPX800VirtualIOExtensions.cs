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
    
    public static Dictionary<int, InputState> GetVirtualInputs(this IIPX800 ipx800)
    {
        return ipx800.GetInputs(InputType.VirtualDigitalInput);
    }
    
    public static int GetVirtualAnalogInput(this IIPX800 ipx800, int inputNumber)
    {
        return ipx800.GetAnalogInput(new Input
        {
            Number = inputNumber,
            Type = InputType.VirtualAnalogInput
        });
    }
    
    public static Dictionary<int, int> GetVirtualAnalogInputs(this IIPX800 ipx800)
    {
        return ipx800.GetAnalogInputs(InputType.VirtualAnalogInput);
    }
    
    public static OutputState GetVirtualOutput(this IIPX800 ipx800, int outputNumber)
    {
        return ipx800.GetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.VirtualOutput
        });
    }
    
    public static Dictionary<int, OutputState> GetVirtualOutputs(this IIPX800 ipx800)
    {
        return ipx800.GetOutputs(OutputType.VirtualOutput);
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
            Type = OutputType.VirtualOutput,
            State = OutputState.Active,
            IsDelayed = true
        });
    }
}