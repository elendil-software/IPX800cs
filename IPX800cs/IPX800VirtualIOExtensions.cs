using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs;

/// <summary>
/// Provide extension methods to facilitate the use of an <see cref="IIPX800"/> implementation instance
/// supporting Virtual inputs
/// </summary>
public static class IPX800VirtualIOExtensions
{
    /// <summary>
    /// Get the state of the virtual input number <paramref name="inputNumber"/>
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <param name="inputNumber">The number of the input</param>
    /// <returns>The state of the input</returns>
    public static InputState GetVirtualInput(this IIPX800 ipx800, int inputNumber)
    {
        return ipx800.GetInput(new Input
        {
            Number = inputNumber,
            Type = InputType.VirtualDigitalInput
        });
    }
    
    /// <summary>
    /// Get the state of the virtual inputs
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <returns>The state of the inputs</returns>
    public static IEnumerable<InputResponse> GetVirtualInputs(this IIPX800 ipx800)
    {
        return ipx800.GetInputs(InputType.VirtualDigitalInput);
    }
    
    /// <summary>
    /// Get the state of the virtual analog input number <paramref name="inputNumber"/>
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <param name="inputNumber">The number of the input</param>
    /// <returns>The state of the input</returns>
    public static double GetVirtualAnalogInput(this IIPX800 ipx800, int inputNumber)
    {
        return ipx800.GetAnalogInput(new AnalogInput
        {
            Number = inputNumber,
            Type = AnalogInputType.VirtualAnalogInput
        });
    }
    
    /// <summary>
    /// Get the state of the virtual analog inputs
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <returns>The state of the inputs</returns>
    public static IEnumerable<AnalogInputResponse> GetVirtualAnalogInputs(this IIPX800 ipx800)
    {
        return ipx800.GetAnalogInputs(AnalogInputType.VirtualAnalogInput);
    }
    
    /// <summary>
    /// Get the state of the virtual output number <paramref name="outputNumber"/>
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <param name="outputNumber">The number of the input</param>
    /// <returns>The state of the output</returns>
    public static OutputState GetVirtualOutput(this IIPX800 ipx800, int outputNumber)
    {
        return ipx800.GetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.VirtualOutput
        });
    }
    
    /// <summary>
    /// Get the state of the virtual outputs
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <returns>The state of the outputs</returns>
    public static IEnumerable<OutputResponse> GetVirtualOutputs(this IIPX800 ipx800)
    {
        return ipx800.GetOutputs(OutputType.VirtualOutput);
    }
    
    /// <summary>
    /// Get the state of the delayed virtual outputs
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <returns>The state of the outputs</returns>
    public static IEnumerable<OutputResponse> GetDelayedVirtualOutputs(this IIPX800 ipx800)
    {
        return ipx800.GetOutputs(OutputType.DelayedVirtualOutput);
    }
    
    /// <summary>
    /// Get the state of the delayed virtual output number <paramref name="outputNumber"/>
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <param name="outputNumber">The number of the input</param>
    /// <returns>The state of the output</returns>
    public static OutputState GetDelayedVirtualOutput(this IIPX800 ipx800, int outputNumber)
    {
        return ipx800.GetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.DelayedVirtualOutput
        });
    }
    
    /// <summary>
    /// Set the state of the virtual output number <paramref name="outputNumber"/> with <paramref name="state"/> 
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <param name="outputNumber">The number of the output</param>
    /// <param name="state">The state to set</param>
    /// <returns><c>true</c> if the command has been correctly received by the IPX800, <c>false</c> otherwise</returns>
    public static bool SetVirtualOutput(this IIPX800 ipx800, int outputNumber, OutputState state)
    {
        return ipx800.SetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.VirtualOutput,
            State = state
        });
    }
    
    /// <summary>
    /// Set the state of the delayed virtual output number <paramref name="outputNumber"/> with state enabled
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <param name="outputNumber">The number of the output</param>
    /// <returns><c>true</c> if the command has been correctly received by the IPX800, <c>false</c> otherwise</returns>
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