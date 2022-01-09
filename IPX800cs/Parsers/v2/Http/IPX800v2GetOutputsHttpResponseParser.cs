using System;
using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v2.Http;

internal class IPX800v2GetOutputsHttpResponseParser : IGetOutputsResponseParser
{
    public IEnumerable<OutputResponse> ParseResponse(string ipxResponse)
    {
        try
        {
            return IPX800v2HttpParserHelper.GetElements(ipxResponse, "led").Select(e =>
            {
                int num = int.Parse(e.Name.LocalName.Substring(3))+1;
                return new OutputResponse
                {
                    Type = OutputType.Output,
                    Number = num,
                    Name = $"Output {num}",
                    State = (OutputState) int.Parse(e.Value)
                };
            }).ToList();
        }
        catch (Exception ex)
        {
            throw new IPX800InvalidResponseException(ipxResponse, ex);
        }
    }
}