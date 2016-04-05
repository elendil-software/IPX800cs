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
using System.Linq;
using System.Text;
using System.Xml.Linq;
using software.elendil.IPX800.CommandSenders;
using software.elendil.IPX800.Enum;
using software.elendil.IPX800.Exceptions;

namespace software.elendil.IPX800.v3.Http
{
	/// <summary>
	/// Base of the HTTP implementations
	/// </summary>
	public abstract class IPX800HttpBase : IIPX800
	{
		protected ICommandSender commandSender;

		#region Build command methods

		/// <summary>
		/// Builds the get state command string.
		/// </summary>
		/// <returns>The command string</returns>
		protected abstract string BuildGetStateCommandString();

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

			if (fugitive)
			{
				command.Append("leds.cgi?led");
				command.Append("=");
				outputNumber--;
				command.Append(outputNumber);
			}
			else
			{
				command.Append("preset.htm?set");
				command.Append(outputNumber);
				command.Append("=");
				command.Append((int) state);
			}

			return command.ToString();
		}

		#endregion

		#region Parse methods

		/// <summary>
		/// Parses the get out response.
		/// </summary>
		/// <param name="outputNumber">The output number.</param>
		/// <param name="xmlDoc">The XML document.</param>
		/// <returns>OutputState.</returns>
		/// <exception cref="System.ArgumentNullException">xmlDoc</exception>
		protected static OutputState ParseGetOutResponse(uint outputNumber, XContainer xmlDoc)
		{
			if (xmlDoc == null) throw new ArgumentNullException("xmlDoc");

			outputNumber--;
			var stateString = xmlDoc.Element("response").Elements("led" + outputNumber).FirstOrDefault().Value;

			OutputState state;
			System.Enum.TryParse(stateString, true, out state);
			return state;
		}

		/// <summary>
		/// Parses the get input response.
		/// </summary>
		/// <param name="inputNumber">The input number.</param>
		/// <param name="xmlDoc">The XML document.</param>
		/// <returns>InputState.</returns>
		/// <exception cref="System.ArgumentNullException">xmlDoc</exception>
		/// <exception cref="System.Exception">Thrown if it was unable to parse the response</exception>
		protected static InputState ParseGetInResponse(uint inputNumber, XContainer xmlDoc)
		{
			if (xmlDoc == null) throw new ArgumentNullException("xmlDoc");

			inputNumber--;
			var stateString = xmlDoc.Element("response").Elements("btn" + inputNumber).FirstOrDefault().Value;

			if ("up".Equals(stateString))
			{
				return InputState.Inactive;
			}
			else if ("dn".Equals(stateString))
			{
				return InputState.Active;
			}
			else
			{
				throw new Exception("Unable to parse '" + stateString + "' response");
			}
		}

		/// <summary>
		/// Parses the get analog response.
		/// </summary>
		/// <param name="inputNumber">The input number.</param>
		/// <param name="xmlDoc">The XML document returned by the IPX800</param>
		/// <returns>The parsed value</returns>
		/// <exception cref="System.ArgumentNullException">xmlDoc</exception>
		protected virtual string ParseGetAnResponse(uint inputNumber, XContainer xmlDoc)
		{
			if (xmlDoc == null) throw new ArgumentNullException("xmlDoc");

			inputNumber--;
			var value = xmlDoc.Element("response").Elements("analog" + inputNumber).FirstOrDefault().Value;
			return value;
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

			try
			{
				command = BuildGetStateCommandString();
				var xmlDoc = (XDocument) commandSender.ExecuteCommand(command);
				var state = ParseGetInResponse(inputNumber, xmlDoc);

				return state;
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
				throw new IPX800Exception("Unable to get a response for command '" + command + "'", e);
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

			try
			{
				command = BuildGetStateCommandString();
				var xmlDoc = (XDocument) commandSender.ExecuteCommand(command);
				var state = ParseGetOutResponse(outputNumber, xmlDoc);

				return state;
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
				throw new IPX800Exception("Unable to get a response for command '" + command + "'", e);
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
#if DEBUG
				Console.WriteLine("SetOut response : " + response);
#endif
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
				throw new IPX800Exception("Unable to get a response '" + response + "' for command '" + command + "'", e);
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

			try
			{
				command = BuildGetStateCommandString();
				var xmlDoc = (XDocument) commandSender.ExecuteCommand(command);
				var state = ParseGetAnResponse(inputNumber, xmlDoc);

				return state;
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
				throw new IPX800Exception("Unable to get a response for command '" + command + "'", e);
			}
		}

		#endregion
	}
}