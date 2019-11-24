using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.M2M
{
    internal class IPX800v3GetInputsM2MResponseParser : IInputsResponseParser
    {
        public Dictionary<int, InputState> ParseResponse(string ipxResponse)
        {
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