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
using Newtonsoft.Json.Linq;
using software.elendil.IPX800.Enum;

namespace software.elendil.IPX800.v4.Http
{
	internal class JsonResponseParser
	{
		public static InputState ParseGetInResponse(string jsonString, uint inputNumber)
		{
			var json = JObject.Parse(jsonString);
			var key = "D" + inputNumber;
			var inputStateString = (string)json[key];
			return (InputState)System.Enum.Parse(typeof(InputState), inputStateString);
		}

        public static InputState ParseGetVirtualInResponse(string jsonString, uint inputNumber)
        {
            var json = JObject.Parse(jsonString);
            var key = "VI" + inputNumber;
            var inputStateString = (string)json[key];
            return (InputState)System.Enum.Parse(typeof(InputState), inputStateString);
        }

        public static OutputState ParseGetOutResponse(string jsonString, uint outputNumber)
		{
			var json = JObject.Parse(jsonString);
			var key = "R" + outputNumber;
			var outputStateString = (string)json[key];
			return (OutputState)System.Enum.Parse(typeof(OutputState), outputStateString);
		}

        public static OutputState ParseGetVirtualOutResponse(string jsonString, uint outputNumber)
        {
            var json = JObject.Parse(jsonString);
            var key = "VO" + outputNumber;
            var outputStateString = (string)json[key];
            return (OutputState)System.Enum.Parse(typeof(OutputState), outputStateString);
        }

        public static string ParseGetAnResponse(string jsonString, uint inputNumber)
		{
			var json = JObject.Parse(jsonString);
			var key = "A" + inputNumber;
			return (string)json[key];
		}

        public static string ParseGetVirtualAnResponse(string jsonString, uint inputNumber)
        {
            var json = JObject.Parse(jsonString);
            var key = "VA" + inputNumber;
            return (string)json[key];
        }

        public static string ParseSetOutResponse(string jsonString)
	    {
            var json = JObject.Parse(jsonString);
            return (string)json["status"];
        }

	    
	}
}

