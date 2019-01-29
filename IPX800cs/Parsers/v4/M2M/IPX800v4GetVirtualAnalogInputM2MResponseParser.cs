﻿namespace software.elendil.IPX800.Parsers.v4.M2M
{
    public class IPX800v4GetVirtualAnalogInputM2MResponseParser : ResponseParserBase, IAnalogInputResponseParser
    {
        public double ParseResponse(string ipxResponse, int inputNumber)
        {
            string result = ExtractValue(ipxResponse, inputNumber);

            if (int.TryParse(result, out int value))
            {
                return value;
            }
            else
            {
                var splitedResult = result.Split('=');
                return double.Parse(splitedResult[1]);
            }
        }
    }
}