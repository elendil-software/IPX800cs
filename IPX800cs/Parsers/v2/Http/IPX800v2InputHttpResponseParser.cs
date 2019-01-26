using System;
using System.Linq;
using System.Xml.Linq;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers.v2.Http
{
    public class IPX800v2InputHttpResponseParser : IInputResponseParser
    {
        public InputState ParseResponse(string ipxResponse, int inputNumber)
        {
            XDocument xmlDoc = XDocument.Parse(ipxResponse);
            
            inputNumber--;
            var stateString = xmlDoc.Element("response").Elements("btn" + inputNumber).First().Value;

            switch (stateString)
            {
                case "up":
                    return InputState.Inactive;
               
                case "dn":
                    return InputState.Active;
                
                default:
                    //TODO throw specific exception
                    throw new Exception("Unable to parse '" + stateString + "' response");
            }
        }
    }
}