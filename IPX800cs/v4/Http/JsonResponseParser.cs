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

