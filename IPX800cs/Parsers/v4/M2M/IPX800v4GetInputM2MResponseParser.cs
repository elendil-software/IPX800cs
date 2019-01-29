﻿using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Parsers.v4.M2M
{
    public class IPX800v4GetInputM2MResponseParser : ResponseParserBase, IInputResponseParser
    {
        public InputState ParseResponse(string ipxResponse, int inputNumber)
        {
            string result = ExtractValue(ipxResponse, inputNumber);

            if (int.TryParse(result, out int value))
            {
                return (InputState)value;
            }
            else
            {
                var splitedResult = result.Split('=');
                return (InputState)int.Parse(splitedResult[1]);
            }
        }
    }
}