using System.Linq;
using System.Xml.Linq;
using IPX800cs.Exceptions;
using IPX800cs.IO;

namespace IPX800cs.Parsers.v2.Http
{
    internal class IPX800v2GetInputHttpResponseParser : IInputResponseParser
    {
        public InputState ParseResponse(string ipxResponse, int inputNumber)
        {
            XDocument xmlDoc = XDocument.Parse(ipxResponse);
            
            inputNumber--;
            var stateString = xmlDoc.Element("response").Elements($"btn{inputNumber}").First().Value;

            switch (stateString)
            {
                case "up":
                    return InputState.Inactive;
               
                case "dn":
                    return InputState.Active;
                
                default:
                    throw new IPX800InvalidResponseException($"Unable to parse '{stateString}' response");
            }
        }
    }
}