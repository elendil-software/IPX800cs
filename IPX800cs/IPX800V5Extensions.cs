using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs;

public static class IPX800V5Extensions
{
    public static InputState GetOptoInput(this IIPX800 ipx800, int inputNumber)
    {
        return ipx800.GetInput(new Input
        {
            Number = inputNumber,
            Type = InputType.OptoInput
        });
    }
    
    public static IEnumerable<InputResponse> GetOptoInputs(this IIPX800 ipx800)
    {
        return ipx800.GetInputs(InputType.OptoInput);
    }

    public static OutputState GetOpenCollectorOutput(this IIPX800 ipx800, int outputNumber)
    {
        return ipx800.GetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.OpenCollectorOutput
        });
    }
    
    public static OutputState GetDelayedOpenCollectorOutput(this IIPX800 ipx800, int outputNumber)
    {
        return ipx800.GetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.DelayedOpenCollectorOutput
        });
    }
    
    public static IEnumerable<OutputResponse> GetOpenCollectorOutputs(this IIPX800 ipx800)
    {
        return ipx800.GetOutputs(OutputType.OpenCollectorOutput);
    }
    
    public static bool SetOpenCollectorOutput(this IIPX800 ipx800, int outputNumber, OutputState state)
    {
        return ipx800.SetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.OpenCollectorOutput,
            State = state
        });
    }
    
    public static IEnumerable<OutputResponse> GetDelayedOpenCollectorOutputs(this IIPX800 ipx800)
    {
        return ipx800.GetOutputs(OutputType.DelayedOpenCollectorOutput);
    }
    
    public static bool SetDelayedOpenCollectorOutput(this IIPX800 ipx800,int outputNumber)
    {
        return ipx800.SetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.DelayedOpenCollectorOutput,
            State = OutputState.Active
        });
    }
}