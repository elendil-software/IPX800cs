using System.Collections.Generic;
using System.Linq;

namespace IPX800cs.Parsers.v4.M2M
{
    internal class AnalogInputsResponseParserBase
    {
        protected Dictionary<int, int> ParseResponse(string ipxResponse, int prefixLength)
        {
            var analogInputs = ipxResponse.Split('&');

            if (ipxResponse.Contains("="))
            {
                var inputStates = analogInputs
                    .Select(e => e.Split('='))
                    .ToDictionary(e => int.Parse(e[0].Substring(prefixLength)), e => int.Parse(e[1]));

                return inputStates;
            }
            else
            {
                var inputStates = new Dictionary<int, int>();
                int inputNumber = 1;

                foreach (string input in analogInputs)
                {
                    inputStates.Add(inputNumber, int.Parse(input));
                    inputNumber++;
                }

                return inputStates;
            }
        }
    }
}