using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.M2M
{
    internal class IPX800v4GetVirtualOutputsM2MResponseParser : IGetOutputsResponseParser
    {
        public Dictionary<int, OutputState> ParseResponse(string ipxResponse)
        { 
            ipxResponse = ipxResponse?.Replace("VO=", "").Replace("&", "");
            ipxResponse.CheckAndGetResponseType();

            var outputStates = new Dictionary<int, OutputState>();
            int inputNumber = 1;

            foreach (char c in ipxResponse.Trim())
            {
                outputStates.Add(inputNumber, c == '1' ? OutputState.Active : OutputState.Inactive);
                inputNumber++;
            }

            return outputStates;
        }
    }
}