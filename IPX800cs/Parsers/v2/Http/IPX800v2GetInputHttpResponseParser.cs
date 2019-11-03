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
            
            inputNumber = InvertInputNumber(inputNumber);
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

        /// <summary>
        /// The status.xml file from IPX800 v2 return the inputs in wrong order.
        /// - btn0 contains state for input 4
        /// - btn1 contains state for input 3
        /// - etc.
        /// </summary>
        /// <param name="inputNumber">Wanted input number, counting from 1 to 4</param>
        /// <returns>Input number in status.xml response</returns>
        private int InvertInputNumber(int inputNumber)
        {
            switch (inputNumber)
            {
                case 1:
                    return 3;
                case 2:
                    return 2;
                case 3:
                    return 1;
                case 4:
                    return 0;
                default:
                    throw new IPX800InvalidContextException($"{inputNumber} is not a valid input number");
            }
        }
    }
}