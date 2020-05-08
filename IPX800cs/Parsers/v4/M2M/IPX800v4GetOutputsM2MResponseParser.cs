using System.Collections.Generic;
using System.Linq;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.M2M
{
    internal class IPX800v4GetOutputsM2MResponseParser : ResponseParserBase, IGetOutputsResponseParser
    {
        public Dictionary<int, OutputState> ParseResponse(string ipxResponse)
        {
            ResponseType responseType = ipxResponse.CheckAndGetResponseType();
        
            if (ipxResponse.Contains("&"))
            {
                var outputStates = ipxResponse.Split('&')
                    .Select(e => e.Split('='))
                    .ToDictionary(e => int.Parse(e[0].Substring(1)), e => (OutputState) int.Parse(e[1]));
                return outputStates;
            }
            else
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
}