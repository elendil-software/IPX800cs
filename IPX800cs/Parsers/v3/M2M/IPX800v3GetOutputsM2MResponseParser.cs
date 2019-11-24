using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.M2M
{
    internal class IPX800v3GetOutputsM2MResponseParser : IGetOutputsResponseParser
    {
        public Dictionary<int, OutputState> ParseResponse(string ipxResponse)
        {
            var outputStates = new Dictionary<int, OutputState>();
            int outputNumber = 1;
            
            foreach (char c in ipxResponse.Trim())
            {
                outputStates.Add(outputNumber, c == '1' ? OutputState.Active : OutputState.Inactive);
                outputNumber++;
            }
            return outputStates;
        }
    }
}