using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs;

/// <summary>
/// Provide extension methods to facilitate the use of an <see cref="IIPX800"/> implementation instance
/// </summary>
public static class IPX800Extensions
{
    /// <summary>
    /// Get the state of the digital input number <paramref name="inputNumber"/>
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <param name="inputNumber">The number of the input</param>
    /// <returns>The state of the input</returns>
    public static InputState GetInput(this IIPX800 ipx800, int inputNumber)
    {
        return ipx800.GetInput(new Input
        {
            Number = inputNumber,
            Type = InputType.DigitalInput
        });
    }
    
    /// <summary>
    /// Get the state of the digital inputs
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <returns>The state of the inputs</returns>
    public static IEnumerable<InputResponse> GetInputs(this IIPX800 ipx800)
    {
        return ipx800.GetInputs(InputType.DigitalInput);
    }
    
    /// <summary>
    /// Get the state of the analog input number <paramref name="inputNumber"/>
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <param name="inputNumber">The number of the input</param>
    /// <returns>The state of the input</returns>
    public static double GetAnalogInput(this IIPX800 ipx800, int inputNumber)
    {
        return ipx800.GetAnalogInput(new AnalogInput
        {
            Number = inputNumber,
            Type = AnalogInputType.AnalogInput
        });
    }

    /// <summary>
    /// Get the state of the analog inputs
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <returns>The state of the inputs</returns>
    public static IEnumerable<AnalogInputResponse> GetAnalogInputs(this IIPX800 ipx800)
    {
        return ipx800.GetAnalogInputs(AnalogInputType.AnalogInput);
    }
    
    /// <summary>
    /// Get the state of the output number <paramref name="outputNumber"/>
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <param name="outputNumber">The number of the output</param>
    /// <returns>The state of the output</returns>
    public static OutputState GetOutput(this IIPX800 ipx800, int outputNumber)
    {
        return ipx800.GetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.Output
        });
    }
    
    /// <summary>
    /// Get the state of the delayed output number <paramref name="outputNumber"/>
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <param name="outputNumber">The number of the output</param>
    /// <returns>The state of the output</returns>
    public static OutputState GetDelayedOutput(this IIPX800 ipx800, int outputNumber)
    {
        return ipx800.GetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.DelayedOutput
        });
    }
    
    /// <summary>
    /// Get the state of the outputs
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <returns>The state of the outputs</returns>
    public static IEnumerable<OutputResponse> GetOutputs(this IIPX800 ipx800)
    {
        return ipx800.GetOutputs(OutputType.Output);
    }

    /// <summary>
    /// Set the state of the output number <paramref name="outputNumber"/> with <paramref name="state"/> 
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <param name="outputNumber">The number of the output</param>
    /// <param name="state">The state to set</param>
    /// <returns><c>true</c> if the command has been correctly received by the IPX800, <c>false</c> otherwise</returns>
    public static bool SetOutput(this IIPX800 ipx800, int outputNumber, OutputState state)
    {
        return ipx800.SetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.Output,
            State = state
        });
    }
    
    /// <summary>
    /// Get the state of the delayed outputs
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <returns>The state of the outputs</returns>
    public static IEnumerable<OutputResponse> GetDelayedOutputs(this IIPX800 ipx800)
    {
        return ipx800.GetOutputs(OutputType.DelayedOutput);
    }
    
    /// <summary>
    /// Set the state of the delayed output number <paramref name="outputNumber"/> to "active"
    /// </summary>
    /// <param name="ipx800">The IPX800 instance</param>
    /// <param name="outputNumber">The number of the output</param>
    /// <returns><c>true</c> if the command has been correctly received by the IPX800, </returns>
    public static bool SetDelayedOutput(this IIPX800 ipx800, int outputNumber)
    {
        return ipx800.SetOutput(new Output
        {
            Number = outputNumber,
            Type = OutputType.DelayedOutput,
            State = OutputState.Active
        });
    }
}