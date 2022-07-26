using System;
using System.Collections.Generic;
using System.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.Http;

internal class IPX800v3GetOutputHttpResponseParser : IGetOutputResponseParser
{
    public OutputState ParseResponse(string ipxResponse, int outputNumber)
    {
        try
        {
            IEnumerable<OutputResponse> response = new IPX800v3GetOutputsHttpResponseParser().ParseResponse(ipxResponse);
            return response.Single(outputResponse => outputResponse.Number == outputNumber).State;
        }
        catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
        {
            throw new IPX800InvalidResponseException(ipxResponse, ex);
        }
    }
}