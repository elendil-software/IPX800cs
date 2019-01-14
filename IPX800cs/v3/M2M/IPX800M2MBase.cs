using System;
using System.Text;
using software.elendil.IPX800.CommandSenders;
using software.elendil.IPX800.Enum;
using software.elendil.IPX800.Exceptions;

namespace software.elendil.IPX800.v3.M2M
{
	/// <summary>
	/// Class IPX800v3Base.
	/// Provide the common methods of an IIPX800 implementation
	/// </summary>
	public abstract class IPX800M2MBase : IIPX800
	{
		protected ICommandSender commandSender;

		#region Build command string methods

		/// <summary>
		/// Builds a command string allowing to get an analog input value.
		/// </summary>
		/// <param name="inputNumber">The input number.</param>
		/// <returns>The command string</returns>
		protected string BuildGetAnCommandString(uint inputNumber)
		{
			var command = (new StringBuilder("GetAn").Append(inputNumber)).ToString();
			return command;
		}

		/// <summary>
		/// Builds a command string allowing to get an output state
		/// </summary>
		/// <param name="outputNumber">The output number</param>
		/// <returns>The command string</returns>
		protected string BuildGetOutCommandString(uint outputNumber)
		{
			var command = new StringBuilder("GetOut").Append(outputNumber).ToString();
			return command;
		}

		/// <summary>
		/// Builds a command string allowing to get an input state
		/// </summary>
		/// <param name="inputNumber">The input number.</param>
		/// <returns>The command string</returns>
		protected string BuildGetInCommandString(uint inputNumber)
		{
			var command = new StringBuilder("GetIn").Append(inputNumber).ToString();
			return command;
		}

		/// <summary>
		/// Builds a command string allowing to set an output state
		/// </summary>
		/// <param name="outputNumber">The output number.</param>
		/// <param name="state">The wanted state.</param>
		/// <param name="fugitive">if set to <c>true</c> use the 'fugitive' mode</param>
		/// <returns>The command string</returns>
		protected virtual string BuildSetOutCommandString(uint outputNumber, OutputState state, bool fugitive)
		{
			var command = new StringBuilder("Set");
			command.Append(outputNumber.ToString("D2"));
			command.Append((int) state);

			if (fugitive)
			{
				command.Append("p");
			}

			return command.ToString();
		}

		#endregion

		#region Parse methods (abstract)

		/// <summary>
		/// Parses the response from a <see cref="GetAn"/> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns>The parsed response</returns>
		protected abstract string ParseGetAnResponse(string responseString);

		/// <summary>
		/// Parses the response from a <see cref="GetOut"/> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns>The parsed response</returns>
		protected abstract OutputState ParseGetOutResponse(string responseString);

		/// <summary>
		/// Parses the response from a <see cref="GetIn"/> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns>The parsed response</returns>
		protected abstract InputState ParseGetInResponse(string responseString);

		/// <summary>
		/// Parses the response from a <see cref="SetOut"/> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns>The parsed response</returns>
		protected abstract bool ParseSetOutResponse(string responseString);

		#endregion

		#region IIPX800 implementation

		/// <summary>
		/// Gets the state of an input
		/// </summary>
		/// <param name="inputNumber">The input number.</param>
		/// <returns>The input state.</returns>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800Exception">Thrown if it was unable to  get a response</exception>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
		public InputState GetIn(uint inputNumber)
		{
			var command = "";
			var response = "";

			try
			{
				command = BuildGetInCommandString(inputNumber);
				response = (string) commandSender.ExecuteCommand(command);
				var result = ParseGetInResponse(response);
				return result;
			}
			catch (IPX800ConnectionException)
			{
				throw;
			}
			catch (IPX800ExecuteException)
			{
				throw;
			}
			catch (Exception e)
			{
				throw new IPX800Exception("Unable to parse response '" + response + "' for command '" + command + "'", e);
			}
		}

		/// <summary>
		/// Gets the state of an output
		/// </summary>
		/// <param name="outputNumber">The output number.</param>
		/// <returns>The output state.</returns>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800Exception">Thrown if it was unable to  get a response</exception>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
		public OutputState GetOut(uint outputNumber)
		{
			var command = "";
			var response = "";

			try
			{
				command = BuildGetOutCommandString(outputNumber);
				response = (string) commandSender.ExecuteCommand(command);
				var result = ParseGetOutResponse(response);
				return result;
			}
			catch (IPX800ConnectionException)
			{
				throw;
			}
			catch (IPX800ExecuteException)
			{
				throw;
			}
			catch (Exception e)
			{
				throw new IPX800Exception("Unable to parse response '" + response + "' for command '" + command + "'", e);
			}
		}

		/// <summary>
		/// Sets the state of an output.
		/// </summary>
		/// <param name="outputNumber">The output number.</param>
		/// <param name="state">The state.</param>
		/// <param name="fugitive">if set to <c>true</c>, the 'fugitive' mode will be used.</param>
		/// <returns><c>true</c> if successful, <c>false</c> otherwise.</returns>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800Exception">Thrown if it was unable to  get a response</exception>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
		public string SetOut(uint outputNumber, OutputState state, bool fugitive)
		{
			var command = "";
			var response = "";

			try
			{
				command = BuildSetOutCommandString(outputNumber, state, fugitive);
				response = (string) commandSender.ExecuteCommand(command);
				return response;
			}
			catch (IPX800ConnectionException)
			{
				throw;
			}
			catch (IPX800ExecuteException)
			{
				throw;
			}
			catch (Exception e)
			{
				throw new IPX800Exception("Unable to parse response '" + response + "' for command '" + command + "'", e);
			}
		}

		/// <summary>
		/// Gets the value of an analog input
		/// </summary>
		/// <param name="inputNumber">The input number.</param>
		/// <returns>The value</returns>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800Exception">Thrown if it was unable to  get a response</exception>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
		public string GetAn(uint inputNumber)
		{
			var command = "";
			var response = "";

			try
			{
				command = BuildGetAnCommandString(inputNumber);
				response = (string) commandSender.ExecuteCommand(command);
				var result = ParseGetAnResponse(response);
				return result;
			}
			catch (IPX800ConnectionException)
			{
				throw;
			}
			catch (IPX800ExecuteException)
			{
				throw;
			}
			catch (Exception e)
			{
				throw new IPX800Exception("Unable to parse response '" + response + "' for command '" + command + "'", e);
			}
		}

		#endregion
	}
}