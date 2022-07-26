using System;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v2.Http;

internal class IPX800v2GetOutputHttpResponseParser : IGetOutputResponseParser
{
    public OutputState ParseResponse(string ipxResponse, int outputNumber)
    {
        try
        {
            outputNumber--;
            int value = IPX800v2HttpParserHelper.ParseValue(ipxResponse, $"led{outputNumber}");
            return (OutputState) value;
        }
        catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
        {
            throw new IPX800InvalidResponseException(ipxResponse, ex);
        }
    }
}