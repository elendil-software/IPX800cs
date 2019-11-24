using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.Legacy.M2M
{
    internal class IPX800v3LegacyGetInputsM2MResponseParser : IInputsResponseParser
    {
        public Dictionary<int, InputState> ParseResponse(string ipxResponse)
        {
            string result = ipxResponse.Trim().Split('=')[1];
            var inputStates = new Dictionary<int, InputState>();
            int inputNumber = 1;
            
            foreach (char c in result)
            {
                inputStates.Add(inputNumber, c == '1' ? InputState.Active : InputState.Inactive);
                inputNumber++;
            }
            
            return inputStates;
        }
    }
}