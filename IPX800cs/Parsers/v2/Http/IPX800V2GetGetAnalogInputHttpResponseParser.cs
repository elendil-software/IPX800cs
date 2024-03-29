﻿using System;
using IPX800cs.Exceptions;

namespace IPX800cs.Parsers.v2.Http;

internal class IPX800V2GetGetAnalogInputHttpResponseParser : IGetAnalogInputResponseParser
{
    public double ParseResponse(string ipxResponse, int inputNumber)
    {
        try
        {
            return IPX800V2HttpParserHelper.ParseValue(ipxResponse, $"an{inputNumber}");
        }
        catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
        {
            throw new IPX800InvalidResponseException(ipxResponse, ex);
        }
    }
}