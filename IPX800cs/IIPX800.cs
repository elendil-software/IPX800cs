﻿using System;
using System.Collections.Generic;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs;

/// <summary>
/// Interface that provide methods to read/set the inputs/outputs state 
/// </summary>
public interface IIPX800 : IDisposable
{
    /// <summary>
    /// Gets the state of an input
    /// </summary>
    /// <param name="input">Input to get</param>
    /// <returns>The current input state.</returns>
    /// <exception cref="IPX800SendCommandException">An error occured while sending the command or it was not possible to send the command</exception>
    /// <exception cref="IPX800NotSupportedCommandException">The command is not supported by the device (e.g. IPX800 v3 does not support virtual inputs)</exception>
    /// <exception cref="IPX800InvalidResponseException">The command has been successfully sent but the response can not be parsed</exception>
    InputState GetInput(Input input);
		
    /// <summary>
    /// Gets the state of all inputs
    /// </summary>
    /// <returns>The current inputs state</returns>
    /// <exception cref="IPX800SendCommandException">An error occured while sending the command or it was not possible to send the command</exception>
    /// <exception cref="IPX800NotSupportedCommandException">The command is not supported by the device (e.g. IPX800 v3 does not support virtual inputs)</exception>
    /// <exception cref="IPX800InvalidResponseException">The command has been successfully sent but the response can not be parsed</exception>
    IEnumerable<InputResponse> GetInputs(InputType inputType);

    /// <summary>
    /// Gets the value of an analog input
    /// </summary>
    /// <param name="input">Input to get</param>
    /// <returns>The current input value</returns>
    /// <exception cref="IPX800SendCommandException">An error occured while sending the command or it was not possible to send the command</exception>
    /// <exception cref="IPX800NotSupportedCommandException">The command is not supported by the device (e.g. IPX800 v3 does not support virtual analog inputs)</exception>
    /// <exception cref="IPX800InvalidResponseException">The command has been successfully sent but the response can not be parsed</exception>
    double GetAnalogInput(AnalogInput input);
        
    /// <summary>
    /// Gets the state of all analog inputs
    /// </summary>
    /// <returns>The current inputs state</returns>
    /// <exception cref="IPX800SendCommandException">An error occured while sending the command or it was not possible to send the command</exception>
    /// <exception cref="IPX800NotSupportedCommandException">The command is not supported by the device (e.g. IPX800 v3 does not support virtual analog inputs)</exception>
    /// <exception cref="IPX800InvalidResponseException">The command has been successfully sent but the response can not be parsed</exception>
    IEnumerable<AnalogInputResponse> GetAnalogInputs(AnalogInputType inputType);

    /// <summary>
    /// Gets the state of an output
    /// </summary>
    /// <param name="output">The output to get.</param>
    /// <returns>The current output state.</returns>
    /// <exception cref="IPX800SendCommandException">An error occured while sending the command or it was not possible to send the command</exception>
    /// <exception cref="IPX800NotSupportedCommandException">The command is not supported by the device (e.g. IPX800 v3 does not support virtual output)</exception>
    /// <exception cref="IPX800InvalidResponseException">The command has been successfully sent but the response can not be parsed</exception>
    OutputState GetOutput(Output output);
        
    /// <summary>
    /// Gets the state of all outputs
    /// </summary>
    /// <returns>The current outputs state</returns>
    /// <exception cref="IPX800SendCommandException">An error occured while sending the command or it was not possible to send the command</exception>
    /// <exception cref="IPX800NotSupportedCommandException">The command is not supported by the device (e.g. IPX800 v3 does not support virtual output)</exception>
    /// <exception cref="IPX800InvalidResponseException">The command has been successfully sent but the response can not be parsed</exception>
    IEnumerable<OutputResponse> GetOutputs(OutputType outputType);

    /// <summary>
    /// Sets the state of an output.
    ///
    /// Important, the method return <c>true</c> if the command has been successfully sent. But it doesn't mean that the IPX800 has correctly set the output.
    /// Use the <see cref="GetOutput"/> method to check the state of the output.
    /// </summary>
    /// <param name="output">The output to set</param>
    /// <returns><c>true</c> if successful, <c>false</c> otherwise.</returns>
    /// <exception cref="IPX800SendCommandException">An error occured while sending the command or it was not possible to send the command</exception>
    /// <exception cref="IPX800NotSupportedCommandException">The command is not supported by the device (e.g. IPX800 v3 does not support virtual output)</exception>
    /// <exception cref="IPX800InvalidResponseException">The command has been successfully sent but the response can not be parsed</exception>
    bool SetOutput(Output output);
}