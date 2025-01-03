﻿using System;
using System.Linq;
using System.Xml.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v2.Http;

internal class IPX800V2GetGetInputHttpResponseParser : IGetInputResponseParser
{
    public InputState ParseResponse(string ipxResponse, int inputNumber)
    {
        try
        {
            XDocument xmlDoc = XDocument.Parse(ipxResponse);

            inputNumber = IPX800V2HttpParserHelper.ConvertInputNumberToBtnIndex(inputNumber);
            var stateString = xmlDoc.Element("response").Elements($"btn{inputNumber}").First().Value;

            return IPX800V2HttpParserHelper.ParseInputStateString(stateString);
        }
        catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
        {
            throw new IPX800InvalidResponseException(ipxResponse, ex);
        }
    }
}