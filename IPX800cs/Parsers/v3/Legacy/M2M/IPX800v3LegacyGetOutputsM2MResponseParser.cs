using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.Legacy.M2M
{
    internal class IPX800v3LegacyGetOutputsM2MResponseParser : IGetOutputsResponseParser
    {
        public Dictionary<int, OutputState> ParseResponse(string ipxResponse)
        {
            ipxResponse.CheckResponse();
            string result = ipxResponse.Trim().Split('=')[1];
            var outputStates = new Dictionary<int, OutputState>();
            int outputNumber = 1;
            
            foreach (char c in result)
            {
                outputStates.Add(outputNumber, c == '1' ? OutputState.Active : OutputState.Inactive);
                outputNumber++;
            }
            return outputStates;
        }
    }
}