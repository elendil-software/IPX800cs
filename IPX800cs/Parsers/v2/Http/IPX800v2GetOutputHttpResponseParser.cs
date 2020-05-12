using System;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v2.Http
{
    internal class IPX800v2GetOutputHttpResponseParser : IPX800v2HttpParserBase, IGetOutputResponseParser
    {
        public OutputState ParseResponse(string ipxResponse, int outputNumber)
        {
            try
            {
                outputNumber--;
                int value = GetValue(ipxResponse, $"led{outputNumber}");
                return (OutputState) value;
            }
            catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
            {
                throw new IPX800InvalidResponseException($"Unable to parse '{ipxResponse}' response", ex);
            }
        }
    }
}