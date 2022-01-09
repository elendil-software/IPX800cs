using System;
using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v2.Http;

internal class IPX800v2GetInputsHttpResponseParser : IPX800v2HttpParserBase, IInputsResponseParser
{
    public IEnumerable<InputResponse> ParseResponse(string ipxResponse)
    {
        try
        {
            return GetElements(ipxResponse, "btn").Select(e =>
            {
                int num = ConvertBtnIndexToInputNumber(int.Parse(e.Name.LocalName.Substring(3)));
                return new InputResponse
                {
                    Type = InputType.DigitalInput,
                    Number = num,
                    Name = $"Input {num}",
                    State = ParseInputStateString(e.Value)
                };
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new IPX800InvalidResponseException(ipxResponse, ex);
        }
    }
}