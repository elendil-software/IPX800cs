using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs;

public static class IPX800Extensions
{
    public static InputState GetInput(this IIPX800 ipx800, int inputNumber)
    {
        return ipx800.GetInput(new Input
        {
            Number = inputNumber,
            Type = InputType.DigitalInput
        });
    }
    
    public static Dictionary<int, InputState> GetInputs(this IIPX800 ipx800)
    {
        return ipx800.GetInputs(InputType.DigitalInput);
    }
    
    public static int GetAnalogInput(this IIPX800 ipx800, int inputNumber)
    {
        return ipx800.GetAnalogInput(new Input
        {
            Number = inputNumber,
            Type = InputType.AnalogInput
        });
    }

    public static Dictionary<int, int> GetAnalogInputs(this IIPX800 ipx800)
    {
        return ipx800.GetAnalogInputs(InputType.AnalogInput);
    }
    
    public static OutputState GetOutput(this IIPX800 ipx800, int outputNumber)
    {
        return ipx800.GetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.Output
        });
    }
    
    public static Dictionary<int, OutputState> GetOutputs(this IIPX800 ipx800)
    {
        return ipx800.GetOutputs(OutputType.Output);
    }
    
    public static bool SetOutput(this IIPX800 ipx800, int outputNumber, OutputState state)
    {
        return ipx800.SetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.Output,
            State = state
        });
    }
    
    public static bool SetDelayedOutput(this IIPX800 ipx800,int outputNumber)
    {
        return ipx800.SetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.Output,
            State = OutputState.Active,
            IsDelayed = true
        });
    }
}