using System.Collections.Generic;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.Http
{
    internal class IPX800v3GetInputHttpResponseParser : IInputResponseParser
    {
        public InputState ParseResponse(string ipxResponse, int inputNumber)
        {
            Dictionary<int, InputState> response = new IPX800v3GetInputsHttpResponseParser().ParseResponse(ipxResponse);
            return response[inputNumber];
        }
    }
}