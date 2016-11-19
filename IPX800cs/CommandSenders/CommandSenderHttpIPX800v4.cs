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
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using software.elendil.IPX800.Exceptions;

namespace software.elendil.IPX800.CommandSenders
{
    public class CommandSenderHttpIPX800V4 : ICommandSender
    {
        /// <summary>
        /// The IP address of the IPX800
        /// </summary>
        protected readonly string ip;

        /// <summary>
        /// The port of the IPX800
        /// </summary>
        protected readonly ushort port;
        protected readonly string pass;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CommandSenderHttp"/> class.
        /// </summary>
        /// <param name="ip">IP of the IPX800</param>
        /// <param name="port">HTTP port of the IPX800</param>
        /// <exception cref="System.ArgumentNullException">ip</exception>
        public CommandSenderHttpIPX800V4(string ip, ushort port)
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
        /// <param name="pass">Password</param>
        /// <exception cref="System.ArgumentNullException">ip</exception>
        public CommandSenderHttpIPX800V4(string ip, ushort port, string pass)
        {
            if (ip == null) throw new ArgumentNullException("ip");
            this.ip = ip;
            this.port = port;
            this.pass = pass;
        }

        #endregion

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

            try
            {
                using (var response = (HttpWebResponse) request.GetResponse())
                {
                    if (HttpStatusCode.OK.Equals(response.StatusCode))
                    {
#if DEBUG
                        Console.WriteLine("Content type : " + response.ContentType);
#endif

                        string jsonResponse;

                        using (var responseStream = response.GetResponseStream())
                        {
                            if (responseStream == null)
                            {
                                throw new IPX800ConnectionException(
                                    "Unable to connect to IPX800, responseStream is null");
                            }

                            var reader = new StreamReader(responseStream);
                            jsonResponse = reader.ReadToEnd();
                            responseStream.Close();
                            response.Close();
                        }

                        return jsonResponse;
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


        private string GetUri(string command)
        {
            var uri = new StringBuilder("http://");
            uri.Append(ip).Append(":").Append(port).Append("/api/xdevices.json?");

            if (!string.IsNullOrWhiteSpace(pass))
            {
                uri.Append("key=").Append(pass).Append("&");
            }

            uri.Append(command);
            return uri.ToString();
        }
    }
}