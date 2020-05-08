using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.M2M
{
    internal class IPX800v4GetInputsM2MResponseParser : ResponseParserBase, IInputsResponseParser
    {
        public Dictionary<int, InputState> ParseResponse(string ipxResponse)
        {
            ResponseType responseType = ipxResponse.CheckAndGetResponseType();
            
            if (ipxResponse.Contains("&"))
            {
                var inputStates = ipxResponse.Split('&')
                    .Select(e => e.Split('='))
                    .ToDictionary(e => int.Parse(e[0].Substring(1)), e => (InputState) int.Parse(e[1]));
                return inputStates;
            }
            else
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
}