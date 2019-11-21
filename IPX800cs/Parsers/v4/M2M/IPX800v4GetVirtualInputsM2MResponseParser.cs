using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.M2M
{
    internal class IPX800v4GetVirtualInputsM2MResponseParser : IInputsResponseParser
    {
        public Dictionary<int, InputState> ParseResponse(string ipxResponse)
        {
            if (ipxResponse.StartsWith("VI="))
            {
                ipxResponse = ipxResponse.Replace("&", "");
                ipxResponse = ipxResponse.Replace("VI=", "");
            }

            var inputStates = new Dictionary<int, InputState>();
            int inputNumber = 1;

            foreach (char c in ipxResponse.Trim())
            {
                inputStates.Add(inputNumber, c == '1' ? InputState.Active : InputState.Inactive);
                inputNumber++;
            }

            return inputStates;
        }
    }
}