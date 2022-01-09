using System;
using System.Linq;
using System.Xml.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v2.Http;

internal class IPX800v2GetInputHttpResponseParser : IPX800v2HttpParserBase, IInputResponseParser
{
    public InputState ParseResponse(string ipxResponse, int inputNumber)
    {
        try
        {
            XDocument xmlDoc = XDocument.Parse(ipxResponse);

            inputNumber = ConvertInputNumberToBtnIndex(inputNumber);
            var stateString = xmlDoc.Element("response").Elements($"btn{inputNumber}").First().Value;

            return ParseInputStateString(stateString);
        }
        catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
        {
            throw new IPX800InvalidResponseException(ipxResponse, ex);
        }
    }
}