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
namespace software.elendil.IPX800.CommandSenders
{
	/// <summary>
	/// Interface ICommandSender. Provide method to send command to an IPX800
	/// </summary>
	public interface ICommandSender
	{
		/// <summary>
		/// Execute the given command
		/// </summary>
		/// <param name="command">the command to execute</param>
		/// <returns>the response to the executed</returns>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		object ExecuteCommand(string command);
	}
}