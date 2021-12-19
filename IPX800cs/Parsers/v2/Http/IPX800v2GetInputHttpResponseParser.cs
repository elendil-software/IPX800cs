using System;
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
            try
            {
                XDocument xmlDoc = XDocument.Parse(ipxResponse);

                inputNumber = InvertInputNumber(inputNumber);
                var stateString = xmlDoc.Element("response").Elements($"btn{inputNumber}").First().Value;

                return stateString switch
                {
                    "up" => InputState.Inactive,
                    "dn" => InputState.Active,
                    _ => throw new IPX800InvalidResponseException(ipxResponse)
                };
            }
            catch (Exception ex) when (!(ex is IPX800InvalidResponseException))
            {
                throw new IPX800InvalidResponseException(ipxResponse, ex);
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
            return inputNumber switch
            {
                1 => 3,
                2 => 2,
                3 => 1,
                4 => 0,
                _ => throw new IPX800InvalidContextException($"{inputNumber} is not a valid input number")
            };
        }
    }
}