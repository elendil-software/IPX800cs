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

namespace software.elendil.IPX800.Exceptions
{
	/// <summary>
	/// Exception that can be thrown by IPX800V2M2M class
	/// </summary>
	public class IPX800Exception : Exception
	{
		/// <summary>
		/// Constructor
		/// </summary>
        public IPX800Exception() { }

        /// <summary>
        /// Constructor
        /// </summary>
		public IPX800Exception(string message) : base(message) { }

        /// <summary>
        /// Constructor
        /// </summary>
		public IPX800Exception(string message, Exception innerException) : base(message, innerException) { }
	}
}
