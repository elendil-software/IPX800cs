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
using software.elendil.IPX800.v3.M2M;

namespace software.elendil.IPX800.v2.M2M
{
	/// <summary>
	/// Class IPX800V2M2M.
	/// 
	/// This is the implementation to use with an IPX800 v2
	/// </summary>
	public class IPX800V2M2M : IPX800M2MLegacy
	{
		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		public IPX800V2M2M(string ip, ushort port) : base(ip, port)
		{
			if (ip == null) throw new ArgumentNullException("ip");
			commandSender = new CommandSenderM2M(ip, port);
		}

		#endregion

		#region Build command methods

		/// <summary>
		/// Builds a command string allowing to set an output state
		/// </summary>
		/// <param name="outputNumber">The output number.</param>
		/// <param name="state">The wanted state.</param>
		/// <param name="fugitive">if set to <c>true</c> use the 'fugitive' mode</param>
		/// <returns>The command string</returns>
		protected override string BuildSetOutCommandString(uint outputNumber, OutputState state, bool fugitive)
		{
			var command = new StringBuilder("Set");
			command.Append(outputNumber);

			if (fugitive)
			{
				command.Append("F");
			}
			else
			{
				command.Append((int) state);
			}

			return command.ToString();
		}

		#endregion
	}
}