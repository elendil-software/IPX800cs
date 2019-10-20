using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.M2M
{
    internal class IPX800v4GetOutputsM2MResponseParser : ResponseParserBase, IGetOutputsResponseParser
    {
        public Dictionary<int, OutputState> ParseResponse(string ipxResponse)
        {
            if (ipxResponse.Contains("&"))
            {
                var inputStates = ipxResponse.Split('&')
                    .Select(e => e.Split('='))
                    .ToDictionary(e => int.Parse(e[0].Substring(1)), e => (OutputState) int.Parse(e[1]));
                return inputStates;
            }
            else
            {
                var inputStates = new Dictionary<int, OutputState>();
                int inputNumber = 1;
                
                foreach (char c in ipxResponse.Trim())
                {
                    inputStates.Add(inputNumber, c == '1' ? OutputState.Active : OutputState.Inactive);
                    inputNumber++;
                }

                return inputStates;
            }
        }
    }
}