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
using software.elendil.IPX800.v3.Http;

namespace software.elendil.IPX800.v2.Http
{
	/// <summary>
	/// IPX800 v2 HTTP implementation
	/// </summary>
	public class IPX800V2Http : IPX800HttpLegacy
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="IPX800V2Http"/> class.
		/// </summary>
		/// <param name="ip">IP of the IPX800</param>
		/// <param name="port">HTTP port of the IPX800</param>
		/// <param name="user">User name</param>
		/// <param name="pass">Password</param>
		/// <exception cref="System.ArgumentNullException">ip</exception>
		public IPX800V2Http(string ip, ushort port, string user, string pass) : base(ip, port, user, pass)
		{
			if (ip == null) throw new ArgumentNullException("ip");
			commandSender = new CommandSenderHttp(ip, port, user, pass);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IPX800V2Http"/> class.
		/// </summary>
		/// <param name="ip">IP of the IPX800</param>
		/// <param name="port">HTTP port of the IPX800</param>
		/// <exception cref="System.ArgumentNullException">ip</exception>
		public IPX800V2Http(string ip, ushort port) : base(ip, port)
		{
			if (ip == null) throw new ArgumentNullException("ip");
			commandSender = new CommandSenderHttp(ip, port);
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
			var command = new StringBuilder("preset.htm?");

			if (fugitive)
			{
				command.Append("RLY");
				command.Append(outputNumber);
				command.Append("=1");
			}
			else
			{
				command.Append("led");
				command.Append(outputNumber);
				command.Append("=");
				command.Append((int) state);
			}

			return command.ToString();
		}

		#endregion

		#region Parse methods

		/// <summary>
		/// Parses the get analog response.
		/// </summary>
		/// <param name="inputNumber">The input number.</param>
		/// <param name="xmlDoc">The XML document returned by the IPX800</param>
		/// <returns>The parsed value</returns>
		/// <exception cref="System.ArgumentNullException">xmlDoc</exception>
		protected override string ParseGetAnResponse(uint inputNumber, XContainer xmlDoc)
		{
			if (xmlDoc == null) throw new ArgumentNullException("xmlDoc");

			var value = xmlDoc.Element("response").Elements("an" + inputNumber).FirstOrDefault().Value;
			return value;
		}

		#endregion
	}
}