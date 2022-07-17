using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs;

/// <summary>
/// Provide extension methods to facilitate the use of a IPX800 V5<see cref="IIPX800"/> implementation instance
/// </summary>
public static class IPX800V5Extensions
{
    
    /// <summary>
    /// Get the state of the opto-isolated input number <paramref name="inputNumber"/>
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <param name="inputNumber">The number of the input</param>
    /// <returns>The state of the input</returns>
    public static InputState GetOptoInput(this IIPX800 ipx800, int inputNumber)
    {
        return ipx800.GetInput(new Input
        {
            Number = inputNumber,
            Type = InputType.OptoInput
        });
    }
    
    /// <summary>
    /// Get the state of the opto-isolated inputs
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <returns>The state of the inputs</returns>
    public static IEnumerable<InputResponse> GetOptoInputs(this IIPX800 ipx800)
    {
        return ipx800.GetInputs(InputType.OptoInput);
    }

    /// <summary>
    /// Get the state of the open-collector output number <paramref name="outputNumber"/>
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <param name="outputNumber">The number of the input</param>
    /// <returns>The state of the output</returns>
    public static OutputState GetOpenCollectorOutput(this IIPX800 ipx800, int outputNumber)
    {
        return ipx800.GetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.OpenCollectorOutput
        });
    }
    
    /// <summary>
    /// Get the state of the delayed open-collector output number <paramref name="outputNumber"/>
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <param name="outputNumber">The number of the input</param>
    /// <returns>The state of the output</returns>
    public static OutputState GetDelayedOpenCollectorOutput(this IIPX800 ipx800, int outputNumber)
    {
        return ipx800.GetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.DelayedOpenCollectorOutput
        });
    }
    
    /// <summary>
    /// Get the state of the open-collector outputs
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <returns>The state of the outputs</returns>
    public static IEnumerable<OutputResponse> GetOpenCollectorOutputs(this IIPX800 ipx800)
    {
        return ipx800.GetOutputs(OutputType.OpenCollectorOutput);
    }
    
    /// <summary>
    /// Set the state of the open-collector output number <paramref name="outputNumber"/> with <paramref name="state"/> 
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <param name="outputNumber">The number of the output</param>
    /// <param name="state">The state to set</param>
    /// <returns><c>true</c> if the command has been correctly received by the IPX800, <c>false</c> otherwise</returns>

    public static bool SetOpenCollectorOutput(this IIPX800 ipx800, int outputNumber, OutputState state)
    {
        return ipx800.SetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.OpenCollectorOutput,
            State = state
        });
    }
    
    /// <summary>
    /// Get the state of the delayed open-collector outputs
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <returns>The state of the outputs</returns>
    public static IEnumerable<OutputResponse> GetDelayedOpenCollectorOutputs(this IIPX800 ipx800)
    {
        return ipx800.GetOutputs(OutputType.DelayedOpenCollectorOutput);
    }
    
    /// <summary>
    /// Set the state of the delayed open-collector output number <paramref name="outputNumber"/> with state enabled
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <param name="outputNumber">The number of the output</param>
    /// <returns><c>true</c> if the command has been correctly received by the IPX800, <c>false</c> otherwise</returns>
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