// This file is part of IPX800 C#.
// Copyright (c) Julien TSCHAPPAT, All rights reserved.
// 
// IPX800 C# is free software; you can redistribute it and/or modify 
// it under the terms of the GNU Lesser General Public License as published by 
// the Free Software Foundation; either version 3.0 of the License, or 
// (at your option) any later version.
// 
// IPX800 C# is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with IPX800 C#. If not, see <https://www.gnu.org/licenses/lgpl.html>

using System;
using System.Text;
using System.Text.RegularExpressions;
using software.elendil.IPX800.CommandSenders;
using software.elendil.IPX800.Enum;
using software.elendil.IPX800.Exceptions;

namespace software.elendil.IPX800.v4.M2M
{
	/// <summary>
	/// Class IPX800M2M.
	/// 
	/// This is the implementation to use with an IPX800 v4
	/// </summary>
	public class IPX800M2M : IIPX800
	{
		protected ICommandSender commandSender;

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="IPX800M2M"/> class.
		/// </summary>
		/// <param name="ip">IP of the IPX800</param>
		/// <param name="port">M2M port of the IPX800</param>
		/// <exception cref="System.ArgumentNullException">ip</exception>
		public IPX800M2M(string ip, ushort port)
		{
			if (ip == null) throw new ArgumentNullException(nameof(ip));
			commandSender = new CommandSenderM2M(ip, port);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IPX800M2M"/> class.
		/// </summary>
		/// <param name="ip">IP of the IPX800</param>
		/// <param name="port">M2M port of the IPX800</param>
		/// <param name="pass">password</param>
		/// <exception cref="System.ArgumentNullException">ip</exception>
		public IPX800M2M(string ip, ushort port, string pass)
		{
			if (ip == null) throw new ArgumentNullException(nameof(ip));
			commandSender = new CommandSenderM2M(ip, port, pass);
		}

		#endregion

		#region Build command string methods

		/// <summary>
		/// Builds a command string allowing to get an analog input value.
		/// </summary>
		/// <param name="inputNumber">The input number.</param>
		/// <returns>The command string</returns>
		protected string BuildGetAnCommandString(uint inputNumber)
		{
			return "Get=A";
		}

		/// <summary>
		/// Builds a command string allowing to get an output state
		/// </summary>
		/// <param name="outputNumber">The output number</param>
		/// <returns>The command string</returns>
		protected string BuildGetOutCommandString(uint outputNumber)
		{
			return "Get=R";
		}

		/// <summary>
		/// Builds a command string allowing to get an input state
		/// </summary>
		/// <param name="inputNumber">The input number.</param>
		/// <returns>The command string</returns>
		protected string BuildGetInCommandString(uint inputNumber)
		{
			return "Get=D";
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
			var command = new StringBuilder();


			switch (state)
			{
					case OutputState.Active:
					command = new StringBuilder("SetR=");
					break;

					case OutputState.Inactive:
					command = new StringBuilder("ClearR=");
					break;
			}

			command.Append(outputNumber.ToString("D2"));
			
			return command.ToString();
		}

		#endregion

		#region Parse methods

		/// <summary>
		/// Parses the response from a <see cref="GetAn" /> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns>The parsed response</returns>
		protected string ParseGetAnResponse(string responseString, uint inputNumber)
		{
			var result = ParseResponse(responseString, 'A', inputNumber);
			return result;
		}

		/// <summary>
		/// Parses the response from a <see cref="GetOut" /> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <param name="outputNumber">The output number that need to be extracted from the answer</param>
		/// <returns>The parsed response</returns>
		private OutputState ParseGetOutResponse(string responseString, uint outputNumber)
		{
			var result = ParseResponse(responseString, 'R', outputNumber);
			return (OutputState)System.Enum.Parse(typeof(OutputState), result);
		}
		
		/// <summary>
		/// Parses the response from a <see cref="GetIn" /> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns>The parsed response</returns>
		protected InputState ParseGetInResponse(string responseString, uint inputNumber)
		{
			var result = ParseResponse(responseString, 'D', inputNumber);
			return (InputState)System.Enum.Parse(typeof(InputState), result);
		}

		/// <summary>
		/// Parses the response from a <see cref="SetOut" /> command
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns>The parsed response</returns>
		protected bool ParseSetOutResponse(string responseString)
		{
			var isSuccessful = "Success".Equals(responseString.Trim());
			return isSuccessful;
		}

		/// <summary>
		/// Determines whether <paramref name="responseString"/> is without header.
		/// </summary>
		/// <param name="responseString">The response string.</param>
		/// <returns><c>true</c> if <paramref name="responseString"/> is without header; otherwise, <c>false</c>.</returns>
		private static bool IsWithoutHeader(string responseString)
		{
			var exp = new Regex("^([0-9]*)$");
			var isWithoutHeader = exp.IsMatch(responseString);
			return isWithoutHeader;
		}

		private static string ParseResponse(string responseString, char type, uint outputNumber)
		{
			string result;

			if (IsWithoutHeader(responseString))
			{
				result = ParseNonHeadedResponse(responseString, (int)outputNumber);
			}
			else
			{
				result = ParseHeadedResponse(responseString, type);
			}
			return result;
		}

		private static string ParseHeadedResponse(string responseString, char type)
		{
			var expWithHeader = new Regex("^((" + type + "[0-9]{1,2}=)([0-1.,]{1})(&?))*$");
			//TODO à corriger après correction de la regex
			var matches = expWithHeader.Matches(responseString);
			return "1";
		}

		private static string ParseNonHeadedResponse(string responseString, int inOutNumber)
		{
			responseString = responseString.Replace("&", "");
			var result = responseString.Substring(inOutNumber - 1, 1);
			return result;
		}

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
				response = (string)commandSender.ExecuteCommand(command);
				var result = ParseGetInResponse(response, inputNumber);
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
				response = (string)commandSender.ExecuteCommand(command);
				var result = ParseGetOutResponse(response, outputNumber);
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
				response = (string)commandSender.ExecuteCommand(command);
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
				response = (string)commandSender.ExecuteCommand(command);
				var result = ParseGetAnResponse(response, inputNumber);
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