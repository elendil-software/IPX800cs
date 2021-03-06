﻿using System;
using System.Collections.Generic;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v3.Http
{
    internal class IPX800v3GetInputHttpResponseParser : IInputResponseParser
    {
        public InputState ParseResponse(string ipxResponse, int inputNumber)
        {
            try
            {
                Dictionary<int, InputState> response = new IPX800v3GetInputsHttpResponseParser().ParseResponse(ipxResponse);
                return response[inputNumber];
            }
            catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
            {
                throw new IPX800InvalidResponseException($"'{ipxResponse}' is not a valid response", ex);
            }
        }
    }
}