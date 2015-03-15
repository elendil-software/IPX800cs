﻿// This file is part of IPX800 C#.
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
using System.Net;
using System.Text;
using System.Xml.Linq;
using software.elendil.IPX800.Exceptions;

namespace software.elendil.IPX800.CommandSenders
{
	/// <summary>
	/// Class CommandSenderHttp.
	/// Provides methods to send HTTP command to an IPX800 v3
	/// </summary>
	public class CommandSenderHttp : ICommandSender
	{
		/// <summary>
		/// The IP address of the IPX800
		/// </summary>
		private readonly string ip;

		/// <summary>
		/// The port of the IPX800
		/// </summary>
		private readonly ushort port;

		private readonly string user;
		private readonly string pass;

		/// <summary>
		/// Initializes a new instance of the <see cref="CommandSenderHttp"/> class.
		/// </summary>
		/// <param name="ip">IP of the IPX800</param>
		/// <param name="port">HTTP port of the IPX800</param>
		/// <exception cref="System.ArgumentNullException">ip</exception>
		public CommandSenderHttp(string ip, ushort port)
		{
			if (ip == null) throw new ArgumentNullException("ip");
			this.ip = ip;
			this.port = port;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CommandSenderHttp"/> class.
		/// </summary>
		/// <param name="ip">IP of the IPX800</param>
		/// <param name="port">HTTP port of the IPX800</param>
		/// <param name="user">User name</param>
		/// <param name="pass">Password</param>
		/// <exception cref="System.ArgumentNullException">ip</exception>
		public CommandSenderHttp(string ip, ushort port, string user, string pass)
		{
			if (ip == null) throw new ArgumentNullException("ip");
			this.ip = ip;
			this.port = port;
			this.user = user;
			this.pass = pass;
		}

		/// <summary>
		/// Execute the given command
		/// </summary>
		/// <param name="command">the command to execute</param>
		/// <returns>the response to the executed</returns>
		/// <exception cref="IPX800ConnectionException">Thrown if unable to connect to IPX800</exception>
		public object ExecuteCommand(string command)
		{
			var uri = GetUri(command);
			var request = (HttpWebRequest) WebRequest.Create(uri);

#if DEBUG
			Console.WriteLine("ExecuteCommand : " + uri);
#endif

			AddAuthorizationHeader(request);

			try
			{
				using (var response = (HttpWebResponse) request.GetResponse())
				{
					if (HttpStatusCode.OK.Equals(response.StatusCode))
					{
						if ("text/xml".Equals(response.ContentType))
						{
							var xml = ReadXML(response);
							return xml;
						}
						else
						{
							return response.StatusDescription;
						}
					}
					else
					{
						return response.StatusDescription;
					}
				}
			}
			catch (WebException e)
			{
				throw new IPX800ConnectionException("Unable to connect to IPX800 : " + e.Message, e);
			}
		}

		private XDocument ReadXML(HttpWebResponse response)
		{
			XDocument xmlDoc;

			using (var responseStream = response.GetResponseStream())
			{
				xmlDoc = XDocument.Load(responseStream);
			}

			return xmlDoc;
		}

		private string GetUri(string command)
		{
			var uri = new StringBuilder("http://");
			uri.Append(ip).Append(":").Append(port).Append("/").Append(command);
			return uri.ToString();
		}

		private void AddAuthorizationHeader(WebRequest request)
		{
			if (!String.IsNullOrWhiteSpace(user) && !String.IsNullOrWhiteSpace(pass))
			{
				var encoded = Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(user + ":" + pass));
				request.Headers.Add("Authorization", "Basic " + encoded);
			}
		}
	}
}