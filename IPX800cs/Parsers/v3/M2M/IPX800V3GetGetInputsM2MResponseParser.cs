using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.M2M;

internal class IPX800V3GetGetInputsM2MResponseParser : IGetInputsResponseParser
{
    public IEnumerable<InputResponse> ParseResponse(string ipxResponse)
    {
        ipxResponse.CheckResponse();
            
        var inputStates = new List<InputResponse>();
        int inputNumber = 1;
            
        foreach (char c in ipxResponse.Trim())
        {
            inputStates.Add(new InputResponse
            {
                Type = InputType.DigitalInput,
                Number = inputNumber,
                Name = $"Input {inputNumber}",
                State = c == '1' ? InputState.Active : InputState.Inactive
            });
            
            inputNumber++;
        }
            
        return inputStates;
    }
}