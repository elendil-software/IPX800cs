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
using software.elendil.IPX800.CommandSenders;

namespace software.elendil.IPX800.v3.Http
{
	/// <summary>
	/// IPX800 v3 HTTP implementation for firmware under version 3.05.42
	/// </summary>
	public class IPX800HttpLegacy : IPX800HttpBase
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="IPX800HttpLegacy"/> class.
		/// </summary>
		/// <param name="ip">IP of the IPX800</param>
		/// <param name="port">HTTP port of the IPX800</param>
		/// <param name="user">User name</param>
		/// <param name="pass">Password</param>
		/// <exception cref="System.ArgumentNullException">ip</exception>
		public IPX800HttpLegacy(string ip, ushort port, string user, string pass)
		{
			if (ip == null) throw new ArgumentNullException("ip");
			commandSender = new CommandSenderHttp(ip, port, user, pass);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IPX800HttpLegacy"/> class.
		/// </summary>
		/// <param name="ip">IP of the IPX800</param>
		/// <param name="port">HTTP port of the IPX800</param>
		/// <exception cref="System.ArgumentNullException">ip</exception>
		public IPX800HttpLegacy(string ip, ushort port)
		{
			if (ip == null) throw new ArgumentNullException("ip");
			commandSender = new CommandSenderHttp(ip, port);
		}

		#endregion

		#region Build command methods

		/// <summary>
		/// Builds the get state command string.
		/// </summary>
		/// <returns>The command string</returns>
		protected override string BuildGetStateCommandString()
		{
			return "status.xml";
		}

		#endregion
	}
}