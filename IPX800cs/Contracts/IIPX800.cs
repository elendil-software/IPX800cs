using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Contracts
{
	public interface IIPX800
	{
		/// <summary>
		/// Gets the state of an input
		/// </summary>
		/// <param name="inputNumber">The input number.</param>
		/// <returns>The current input state.</returns>
		/// <exception cref="IPX800SendCommandException">Thrown if it was unable to send the command or if an error occured while sending the command</exception>
		/// <exception cref="IPX800InvalidResponseException">Thrown if the command has been successfully sent but the response can not be parsed</exception>
		InputState GetInput(int inputNumber);

        /// <summary>
        /// Gets the value of an analog input
        /// </summary>
        /// <param name="inputNumber">The input number.</param>
        /// <returns>The current input value</returns>
        /// <exception cref="IPX800SendCommandException">Thrown if it was unable to send the command or if an error occured while sending the command</exception>
        /// <exception cref="IPX800InvalidResponseException">Thrown if the command has been successfully sent but the response can not be parsed</exception>
        int GetAnalogInput(int inputNumber);

        /// <summary>
        /// Gets the state of an output
        /// </summary>
        /// <param name="outputNumber">The output number.</param>
        /// <returns>The current output state.</returns>
        /// <exception cref="IPX800SendCommandException">Thrown if it was unable to send the command or if an error occured while sending the command</exception>
        /// <exception cref="IPX800InvalidResponseException">Thrown if the command has been successfully sent but the response can not be parsed</exception>
        OutputState GetOutput(int outputNumber);

        /// <summary>
        /// Sets the state of an output.
        ///
        /// Important, the method return <c>true</c> if the command has been successfully sent. But it doesn't mean that the IPX800 has correctly set the output.
        /// Use the <see cref="GetOutput"/> method to check the state of the output.
        /// </summary>
        /// <param name="outputNumber">The output number.</param>
        /// <param name="state">The state to set</param>
        /// <returns><c>true</c> if successful, <c>false</c> otherwise.</returns>
        /// <exception cref="IPX800SendCommandException">Thrown if it was unable to send the command or if an error occured while sending the command</exception>
        /// <exception cref="IPX800InvalidResponseException">Thrown if the command has been successfully sent but the response can not be parsed</exception>
        bool SetOutput(int outputNumber, OutputState state);

        /// <summary>
        /// Enables an output configured in delayed mode (also called "fugitive" mode)
        ///
        /// Important, the method return <c>true</c> if the command has been successfully sent. But it doesn't mean that the IPX800 has correctly set the output.
        /// Use the <see cref="GetOutput"/> method to check the state of the output.
        /// </summary>
        /// <param name="outputNumber">The output number.</param>
        /// <returns><c>true</c> if successful, <c>false</c> otherwise.</returns>
        /// <exception cref="IPX800SendCommandException">Thrown if it was unable to send the command or if an error occured while sending the command</exception>
        /// <exception cref="IPX800InvalidResponseException">Thrown if the command has been successfully sent but the response can not be parsed</exception>
        bool SetDelayedOutput(int outputNumber);
	}
}