using System;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v4.Http
{
    internal class IPX800v4GetVirtualInputHttpResponseParser : IPX800v4HttpParserBase, IInputResponseParser
    {
        public InputState ParseResponse(string ipxResponse, int inputNumber)
        {
            try
            {
                return (InputState) ParseValue(ipxResponse, $"VI{inputNumber}");
            }
            catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
            {
                throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response", ex);
            }
        }
    }
}