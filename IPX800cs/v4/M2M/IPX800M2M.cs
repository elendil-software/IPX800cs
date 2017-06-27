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
using software.elendil.IPX800.CommandSenders;
using software.elendil.IPX800.Enum;
using software.elendil.IPX800.Exceptions;
using software.elendil.IPX800.v4.M2M.Parsers;

namespace software.elendil.IPX800.v4.M2M
{
	/// <summary>
	/// Class IPX800M2M.
	/// 
	/// This is the implementation to use with an IPX800 v4
	/// </summary>
	public class IPX800M2M : IIPX800v4
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
		/// Builds a command string allowing to set an output state
		/// </summary>
		/// <param name="outputNumber">The output number.</param>
		/// <param name="state">The wanted state.</param>
		/// <returns>The command string</returns>
		protected string BuildSetOutCommandString(uint outputNumber, OutputState state, bool isVirtual)
		{
			var command = new StringBuilder();
			var outputType = isVirtual ? "VO" : "R";

			switch (state)
			{
					case OutputState.Active:
					command = new StringBuilder($"Set{outputType}=");
					break;

					case OutputState.Inactive:
					command = new StringBuilder($"Clear{outputType}=");
					break;
			}

			command.Append(outputNumber.ToString("D2"));
			
			return command.ToString();
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
			var command = "Get=D";
			var response = "";

			try
			{
				response = (string)commandSender.ExecuteCommand(command);
				var result = new InputResponseParser().ParseResponse(response, inputNumber);
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
			var command = "Get=R";
			var response = "";

			try
			{
				response = (string)commandSender.ExecuteCommand(command);
				var result = new OutputResponseParser().ParseResponse(response, outputNumber);
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
				command = BuildSetOutCommandString(outputNumber, state, false);
				response = (string)commandSender.ExecuteCommand(command);
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
			var command = "Get=A";
			var response = "";

			try
			{
				response = (string)commandSender.ExecuteCommand(command);
				var result = new AnalogResponseParser().ParseResponse(response, inputNumber);
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
		
		#region IIPX800 implementation

		public InputState GetVirtualIn(uint inputNumber)
		{
			var command = "Get=VI";
			var response = "";

			try
			{
				response = (string)commandSender.ExecuteCommand(command);
				var result = new VirtualInputResponseParser().ParseResponse(response, inputNumber);
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

		public OutputState GetVirtualOut(uint outputNumber)
		{
			var command = "Get=VO";
			var response = "";

			try
			{
				response = (string)commandSender.ExecuteCommand(command);
				var result = new VirtualOutputResponseParser().ParseResponse(response, outputNumber);
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

		public string SetVirtualOut(uint outputNumber, OutputState state, bool fugitive)
		{
			var command = "";
			var response = "";

			try
			{
				command = BuildSetOutCommandString(outputNumber, state, true);
				response = (string)commandSender.ExecuteCommand(command);
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
				throw new IPX800Exception("Unable to parse response '" + response + "' for command '" + command + "'", e);
			}
		}

		public string GetVirtualAn(uint inputNumber)
		{
			var command = "Get=VA";
			var response = "";

			try
			{
				response = (string)commandSender.ExecuteCommand(command);
				var result = new VirtualAnalogResponseParser().ParseResponse(response, inputNumber);
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