using IPX800cs.IO;

namespace IPX800cs.Contracts
{
	public interface IIPX800
	{
		/// <summary>
		/// Gets the state of an input
		/// </summary>
		/// <param name="inputNumber">The input number.</param>
		/// <returns>The input state.</returns>
		/// <exception cref="IPX800Exception">Thrown if it was unable to  get a response</exception>
		/// <exception cref="IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		/// <exception cref="IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
		InputState GetInput(int inputNumber);
		
		/// <summary>
		/// Gets the value of an analog input
		/// </summary>
		/// <param name="inputNumber">The input number.</param>
		/// <returns>The value</returns>
		/// <exception cref="IPX800Exception">Thrown if it was unable to  get a response</exception>
		/// <exception cref="IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		/// <exception cref="IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
		double GetAnalogInput(int inputNumber);

		/// <summary>
		/// Gets the state of an output
		/// </summary>
		/// <param name="outputNumber">The output number.</param>
		/// <returns>The output state.</returns>
		/// <exception cref="IPX800Exception">Thrown if it was unable to  get a response</exception>
		/// <exception cref="IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		/// <exception cref="IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
		OutputState GetOutput(int outputNumber);

		/// <summary>
		/// Sets the state of an output.
		/// </summary>
		/// <param name="outputNumber">The output number.</param>
		/// <param name="state">The state.</param>
		/// <param name="fugitive">if set to <c>true</c>, the 'fugitive' mode will be used.</param>
		/// <returns><c>true</c> if successful, <c>false</c> otherwise.</returns>
		/// <exception cref="IPX800Exception">Thrown if it was unable to  get a response</exception>
		/// <exception cref="IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		/// <exception cref="IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
		bool SetOutput(int outputNumber, OutputState state);
		
		
		bool SetDelayedOutput(int outputNumber);
	}
}