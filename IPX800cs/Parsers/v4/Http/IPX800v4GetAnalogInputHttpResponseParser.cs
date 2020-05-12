using System;
using IPX800cs.Exceptions;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetAnalogInputHttpResponseParser : IPX800v4HttpParserBase, IAnalogInputResponseParser
    {
        public int ParseResponse(string ipxResponse, int inputNumber)
        {
            try
            {
                return ParseValue(ipxResponse, $"A{inputNumber}");
            }
            catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
            {
                throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response", ex);
            }
        }
    }
}