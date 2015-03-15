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
using software.elendil.IPX800.Enum;

namespace software.elendil.IPX800
{
	/// <summary>
	/// Interface IIPX800.
	/// 
	/// Contract providing methods to communicate with an IPX800
	/// </summary>
	public interface IIPX800
	{
		/// <summary>
		/// Gets the state of an input
		/// </summary>
		/// <param name="inputNumber">The input number.</param>
		/// <returns>The input state.</returns>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800Exception">Thrown if it was unable to  get a response</exception>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
		InputState GetIn(uint inputNumber);

		/// <summary>
		/// Gets the state of an output
		/// </summary>
		/// <param name="outputNumber">The output number.</param>
		/// <returns>The output state.</returns>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800Exception">Thrown if it was unable to  get a response</exception>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
		OutputState GetOut(uint outputNumber);

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
		string SetOut(uint outputNumber, OutputState state, bool fugitive);

		/// <summary>
		/// Gets the value of an analog input
		/// </summary>
		/// <param name="inputNumber">The input number.</param>
		/// <returns>The value</returns>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800Exception">Thrown if it was unable to  get a response</exception>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		/// <exception cref="software.elendil.IPX800.Exceptions.IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
		string GetAn(uint inputNumber);
	}
}