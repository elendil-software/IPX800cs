using System;
using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v2.Http;

internal class IPX800v2GetAnalogInputsHttpResponseParser : IAnalogInputsResponseParser
{
    public IEnumerable<AnalogInputResponse> ParseResponse(string ipxResponse)
    {
        try
        {
            return IPX800v2HttpParserHelper.GetElements(ipxResponse, "an").Select(e =>
                new AnalogInputResponse
                {
                    Type = AnalogInputType.AnalogInput,
                    Number = int.Parse(e.Name.LocalName.Substring(2)),
                    Name = $"Analog {e.Name.LocalName.Substring(2)}",
                    Value = int.Parse(e.Value)
                }).ToList();
        }
        catch (Exception ex)
        {
            throw new IPX800InvalidResponseException($"Unable to parse '{ipxResponse}' response", ex);
        }
    }
}